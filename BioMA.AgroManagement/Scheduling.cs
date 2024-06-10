using System;
using System.Data;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Xml;
using CRA.ModelLayer.Core;
using System.Xml.XPath;
using System.Configuration;

using System.Xml.Schema;
using System.Collections.Generic;

using CRA.AgroManagement.Writers;
using System.Linq;

namespace CRA.AgroManagement
{
    /// <summary>
    /// Methods to load an agro-managemnt configuration and to test rules at run-time.
    /// </summary>
    public class Scheduling
    {
        public ITestsOutput PreconditionsWriter { get; set; }

        #region Fields

        private IRules[] r;						//IRules
        private IManagement[] m;				//IManagement
        private List<Assembly> RuleAssemblies = new List<Assembly>();
        private List<Assembly> ImpactAssemblies = new List<Assembly>();

        #endregion

        #region Constructor

        // DF - 2/7/2019 - refactoring azure

        /// <summary>
        /// Constructor: load assemblies with rules and impacts from AppDomain.
        /// Force loading assemblies as dependency injection in client code by
        /// instantiating the "well-known object" LoadForcer
        /// </summary>
        public Scheduling()
        {
            var impactsAssemblies = new List<Assembly>();
            var rulesAssemblies = new List<Assembly>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                try
                {
                    var types = assembly.GetTypes().Where(p => typeof(IManagement).IsAssignableFrom(p) && (!p.IsAbstract)).ToList();
                    if (types.Count > 0)
                    {
                        impactsAssemblies.Add(assembly);
                    }
                    types = assembly.GetTypes().Where(p => typeof(IRules).IsAssignableFrom(p) && (!p.IsAbstract)).ToList();
                    if (types.Count > 0)
                    {
                        rulesAssemblies.Add(assembly);
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    //ignore it
                }
            }

            ImpactAssemblies = impactsAssemblies;
            RuleAssemblies = rulesAssemblies;
        }

        /// <summary>
        /// Constructor: load assemblies with rules and impacts
        /// from a dedicated configuration file.
        /// </summary>
        //public Scheduling()
        //{
        //    // Load default assemblies of rules and impacts
        //    // Environment.CurrentDirectory = XmlIO.AGROMANAGEMENT_DIR;  MD 10042014

        //    try
        //    {
        //        RuleAssemblies.Add(Assembly.LoadFrom("CRA.AgroManagement2014.Rules.dll"));
        //        ImpactAssemblies.Add(Assembly.LoadFrom("CRA.AgroManagement2014.Impacts.dll"));
        //    }
        //    catch (Exception err)
        //    {
        //        string msg = "The default assembly of rules (CRA.AgroManagement2014.Rules.dll)\t\n";
        //        msg += "and the default assembly of impacts (CRA.AgroManagement2014.Impacts.dll)\t\n";
        //        msg += "could not be loaded. Are files in the same dir of CRA.AgroManagement2014.dll?";
        //        throw new Exception(msg, err);
        //    }

        //    // 10042014 MD problemi in ambiente NUnit
        //    //string path =
        //    //    XmlIO.AGROMANAGEMENT_DIR +
        //    //    System.IO.Path.DirectorySeparatorChar +
        //    //  XmlIO.CONFIG_FILE;

        //    //Loads the current configuration
        //    try
        //    {
        //        LoadConfiguration(XmlIO.CONFIG_FILE); 
        //    }
        //    catch (Exception err)
        //    {
        //        string msg = "The configuration file\t\n";
        //        msg += XmlIO.CONFIG_FILE + "\t\n";
        //        msg += "could not be loaded. Is the file in the same dir of CRA.AgroManagement2014.dll?";
        //        throw new Exception(msg, err);
        //    } 

        //}
        //public Scheduling() : this(XmlReader.Create(XmlIO.CONFIG_FILE)) { }

        // DF - 2/7/2019 - refactoring azure
        //public Scheduling(XmlReader reader)
        //{
        //    try
        //    {
        //        // TODO: DFa 05/04/2020 riconsiderare. In ambiente Azure (o di test DevOps) non è detto che si possa
        //        // sempre sfruttare il famigerato "bin/Debug"
        //        //string dllLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
        //        //RuleAssemblies.Add(Assembly.LoadFrom(dllLocation + "BioMA.AgroManagement.Rules.NetFramework.dll"));
        //        //ImpactAssemblies.Add(Assembly.LoadFrom(dllLocation + "BioMA.AgroManagement.Impacts.NetFramework.dll"));
        //    }
        //    catch (Exception err)
        //    {
        //        string msg = "The default assembly of rules (BioMA.AgroManagement.Rules.NetFramework.dll)\t\n";
        //        msg += "and the default assembly of impacts (BioMA.AgroManagement.Impacts.NetFramework.dll)\t\n";
        //        msg += "could not be loaded. Are files in the same dir of BioMA.AgroManagement.NetFramework.dll?";
        //        throw new Exception(msg, err);
        //    }

        //    // 10042014 MD problemi in ambiente NUnit
        //    //string path =
        //    //    XmlIO.AGROMANAGEMENT_DIR +
        //    //    System.IO.Path.DirectorySeparatorChar +
        //    //  XmlIO.CONFIG_FILE;

        //    //Loads the current configuration
        //    try
        //    {
        //        LoadConfiguration(reader);
        //    }
        //    catch (Exception err)
        //    {
        //        string msg = "The configuration file\t\n";
        //        msg += XmlIO.CONFIG_FILE + "\t\n";
        //        msg += "could not be loaded. Is the file in the same dir of BioMA.AgroManagement.NetFramework.dll?";
        //        throw new Exception(msg, err);
        //    }
        //}

        // DF - 2/7/2019 - refactoring azure
        //private void LoadConfiguration(XmlReader reader)
        //{
        //    XmlDocument doc = new XmlDocument();

        //    try
        //    {
        //        // Read the template
        //        doc.Load(reader);

        //        // Fill data structure
        //        foreach (XmlNode type in doc.DocumentElement.ChildNodes)
        //        {
        //            if (type.NodeType != XmlNodeType.Element)
        //            {
        //                continue;
        //            }

        //            if (type.Name == XmlIO.EXTERNAL_ASSEMBLIES_TAG)
        //            {
        //                foreach (XmlNode assNode in type.ChildNodes)
        //                {
        //                    if (assNode.Name == XmlIO.ASSEMBLY_TAG)
        //                    {
        //                        if (assNode.Attributes[XmlIO.ATTRIBUTE_TYPE].Value == XmlIO.ATTRIBUTE_TYPE_RULES)
        //                            // TODO: DFa 05/04/2020 riconsiderare. In ambiente Azure (o di test DevOps) non è detto che si possa
        //                            // sempre sfruttare il famigerato "bin/Debug"
        //                            RuleAssemblies.Add(Assembly.Load(assNode.Attributes[XmlIO.ATTRIBUTE_NAME].Value));
        //                        else if (assNode.Attributes[XmlIO.ATTRIBUTE_TYPE].Value == XmlIO.ATTRIBUTE_TYPE_IMPACTS)
        //                            // TODO: DFa 05/04/2020 riconsiderare. In ambiente Azure (o di test DevOps) non è detto che si possa
        //                            // sempre sfruttare il famigerato "bin/Debug"
        //                            ImpactAssemblies.Add(Assembly.Load(assNode.Attributes[XmlIO.ATTRIBUTE_NAME].Value));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (XmlException ex)
        //    {
        //        TraceAgroManagement.TraceEvent(System.Diagnostics.TraceEventType.Warning,
        //            103, "Either the Xml is not present or it is not well-formed; empty data were used. "
        //            + ex.Message);
        //    }
        //    catch (Exception ex2)
        //    {
        //        TraceAgroManagement.TraceEvent(System.Diagnostics.TraceEventType.Warning,
        //            104, "An assembly could not be loaded. " + ex2.Message);
        //        throw new Exception("An  external agromanagement assembly could not be loaded. " + ex2.Message);//davidefuma 20/06/2013 added exception because that trace is almost invisible
        //        return;
        //    }
        //}

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="assemblies">Assemblies of impacts passed 
        /// by the caller</param>
        //public Scheduling(Assembly[] assemblies)
        //    : this()
        //{
        //    Assembly ass = null;
        //    if (assemblies == null)
        //        return;
        //    foreach (Assembly item in assemblies)
        //    {
        //        try
        //        {
        //            ass = Assembly.Load(item.GetName());
        //        }
        //        catch
        //        {
        //            continue;
        //        }
        //    }
        //}

        #endregion

        #region Properties

        private int intRotationLength = -1;
        /// <summary>
        /// Retrieves the current RotationLength
        /// </summary>
        public int RotationLength
        {
            get
            {
                return intRotationLength;
            }
        }

        private SchEvents sc = new SchEvents();
        /// <summary>
        /// List of planned actions (couples rule-impact)
        /// </summary>
        public SchEvents Events
        {
            get
            {
                return sc;
            }
        }

        #endregion

        #region Test rules
        /// <summary>
        /// Test of all rules at each time step
        /// </summary>
        /// <param name="st">Object with state values to be used in tests</param>
        /// <returns>Object with array of IManagement to be published</returns>
        public ActEvents CheckManagement(StatesAgroMan st)
        {
            ActEvents a = new ActEvents();
            a.ProductionActivity = sc.ProductionActivity;
            //for each rule make test
            //if true, add corresponding management object 
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i].CheckRule(st, m[i]))
                {
                    //adds relevant management object to be passed to model components
                    //more than one event may occur at a given call
                    a.Management.Add(m[i]);
                }
            }
            return a;
        }

        /// <summary>
        /// Test preconditions of both rules matched and states when checking all rules
        /// </summary>
        /// <param name="st">States relevant to rules</param>
        /// <param name="callID">Identifier from caller</param>
        /// <returns>Object with array of IManagement to be published</returns>
        public ActEvents CheckManagement(StatesAgroMan st, string callID)
        {
            string result = String.Empty;
            ActEvents a = new ActEvents();
            a.ProductionActivity = sc.ProductionActivity;
            Preconditions pr = new Preconditions();

            // 19/11/2021 - configure PreconditionsWriter
            st.PreconditionsWriter = PreconditionsWriter;
            result = st.TestPreconditions(callID); //preconditions of states

            //for each rule make test
            //if true, add corresponding management object 
            for (int i = 0; i < r.Length; i++)
            {
                // 19/11/2021 - configure PreconditionsWriter
                r[i].PreconditionsWriter = PreconditionsWriter;
                if (r[i].CheckRule(st, m[i]))
                {
                    //Test pre-conditions of specific rule
                    result += r[i].TestPreConditions(m[i], callID);
                    //adds relevant management object to be passed to model components
                    //more than one event may occur at a given call
                    //write test of preconditions
                    if (result == String.Empty)
                    {
                        a.Management.Add(m[i]);
                    }
                    else
                    {
                        pr.TestsOut(result, true, "  AgroManagement.");
                        TraceAgroManagement.TraceEvent(System.Diagnostics.TraceEventType.Warning,
                                106, "At least a test of either AgroManStates or Rule parameters failed. See log file for details." +
                                "Impact object(s) corresponding to a failed test were not published.");
                    }
                }
            }
            return a;
        }
        #endregion

        #region Read agromanagement configuration
        /// <summary>
        /// Read management configuration from file or XML fragment.
        /// </summary>
        /// <param name="file">XML file name boolean</param>
        /// <param name="xmlObject">XML object</param>
        public void InitManagement(string xmlObject, bool file)
        {
            sc = ReadXMLmanagement(xmlObject, file);
            if (sc != null)
                InitializeManagement(xmlObject.ToString());
        }

        /// <summary>
        /// Read management from node.
        /// </summary>
        /// <param name="node"></param>
        public void InitManagement(XmlNode node)
        {
            sc = ReadXMLmanagement(node);
            if (sc != null)
                InitializeManagement(node.ToString());
        }

        //Convert ArrayLists into arrays
        private void InitializeManagement(string source)
        {
            int elements = sc.Rules.Count;
            //from ArrayLists to arrays
            if (elements > 0)
            {
                m = new IManagement[elements];
                r = new IRules[elements];
                sc.Management.CopyTo(0, m, 0, elements);
                sc.Rules.CopyTo(0, r, 0, elements);
                // 19/11/2021 - configure PreconditionsWriter
                foreach (IManagement management in m)
                {
                    management.PreconditionsWriter = PreconditionsWriter;
                }
            }
            //Test preconditions for impact parameters (rules can be tested at run time,
            //when StatesAgroman get a value
            Preconditions pr = new Preconditions();
            int count = 0;
            string _result = String.Empty;
            string callID = "AgroManagement configuration - source " + source.ToString();
            for (count = 0; count < elements; count++)
            {
                // 19/11/2021 - configure PreconditionsWriter
                r[count].PreconditionsWriter = PreconditionsWriter;
                //test preconditions
                _result += r[count].TestPreConditions(m[count], callID);
            }
            if (_result != "")
            {
                //Console.WriteLine replaced with writing on file
                // 19/11/2021 - configure PreconditionsWriter
                //pr.TestsOut(_result, true, callID);
                pr.TestsOut(PreconditionsWriter, _result, true, callID);
                TraceAgroManagement.TraceEvent(System.Diagnostics.TraceEventType.Warning,
                    101, "One or more pre-conditions violated while loading the AgroManagement file, see file log.");
            }
        }
        #endregion

        #region Save record of management events
        /// <summary>
        /// Save all values of management applied. 
        /// </summary>
        /// <param name="a">Object with IManagement objects</param>
        /// <param name="w">Instance of a writer</param>
        /// <param name="callID">Identifier from caller</param>
        public void SaveRecordAppliedManagement(ActEvents a, IWriters w, string callID)
        {
            ContextWriter cw = new ContextWriter(w);
            cw.WriteOut(a, callID);
        }
        #endregion

        #region Read XML - file or text
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public SchEvents ReadXMLmanagement(XmlNode n)
        {
            sc.Rules.Clear();
            sc.Management.Clear();

            foreach (XmlNode node in n.ChildNodes)
            {
                IRules rule = null;
                IManagement impact = null;

                switch (node.Name)
                {
                    case (XML_TAGS.ACTION):
                        XmlNodeList list = node.ChildNodes;
                        string assembly = String.Empty;
                        string ruleName = String.Empty;
                        string impactName = String.Empty;
                        foreach (XmlNode item in node.ChildNodes)
                        {
                            if (item.Name == XML_TAGS.RULE)
                            {
                                assembly = item.Attributes[XML_TAGS.RULE_ASSEMBLY].InnerText;
                                ruleName = item.Attributes[XML_TAGS.RULE_NAME].InnerText;
                                Type t = null;
                                //load assembly 
                                try
                                {
                                    Assembly dataAssembly = null;
                                    foreach (Assembly a in RuleAssemblies)
                                    {
                                        if (a.GetName().Name == assembly)
                                        {
                                            dataAssembly = a;
                                            break;
                                        }
                                    }

                                    if (dataAssembly != null)  // MD 11042014
                                    {
                                        foreach (Type type in dataAssembly.GetTypes())
                                        {
                                            t = null;
                                            if (type.Name == ruleName)
                                            {
                                                t = type;
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {
                                    string msg = "Component AgroManagement.\t\n";
                                    msg += "Could not load the assembly " + assembly.ToString() + ".\t\n";
                                    throw new Exception(msg + err.Message);
                                }
                                //continue if t not null
                                //create instance
                                if (t != null)
                                {
                                    try
                                    {
                                        rule = (IRules)Activator.CreateInstance(t);
                                        //Use class XML read method
                                        rule.LoadXml(item);
                                    }
                                    catch (Exception err)
                                    {
                                        string msg = "Component AgroManagement.\t\n";
                                        msg += "Either could not create instance of rule " + t.Name;
                                        msg += "or in the input file there was a missing value for a rule property" + ".\t\n";
                                        throw new Exception(msg + err.Message);
                                    }
                                }
                            }
                            if (item.Name == XML_TAGS.IMPACT)
                            {
                                assembly = item.Attributes[XML_TAGS.IMPACT_ASSEMBLY].InnerText;
                                impactName = item.Attributes[XML_TAGS.IMPACT_NAME].InnerText;
                                //load assembly
                                Type t = null;
                                try
                                {
                                    Assembly dataAssembly = null;
                                    foreach (Assembly a in ImpactAssemblies)
                                    {
                                        if (a.GetName().Name == assembly)
                                        {
                                            dataAssembly = a;
                                            break;
                                        }
                                    }
                                    if (dataAssembly != null)  // MD 11042014
                                    {
                                        foreach (Type type in dataAssembly.GetTypes())
                                        {
                                            t = null;
                                            if (type.Name == impactName)
                                            {
                                                t = type;
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {
                                    string msg = "Component AgroManagement.\t\n";
                                    msg += "Could not load the assembly " + assembly.ToString() + ".\t\n";
                                    throw new Exception(msg + err.Message);
                                }
                                //continue if t not null
                                //make instance
                                if (t != null)
                                {
                                    try
                                    {
                                        impact = (IManagement)Activator.CreateInstance(t);
                                        //Use class XML read method
                                        impact.LoadXml(item);
                                    }
                                    catch (Exception err)
                                    {
                                        string msg = "Component AgroManagement.\t\n";
                                        msg += "Either could not create instance of impact " + t.Name + ",\t\n";
                                        msg += "or in the input file there was a missing value for an impact property";
                                        throw new Exception(msg + err.Message);
                                    }
                                }
                                continue;
                            }
                        }
                        if (rule != null & impact != null)
                        {
                            sc.Rules.Add(rule);
                            sc.Management.Add(impact);
                        }
                        else
                        {
                            string msg = "The couple RULE = " + ruleName + " - IMPACT = " + impactName + " specified in AgroManagement input XML configuration\t\n";
                            msg += "could not be added to scheduled events: ";
                            msg += "it was not possible to create an instance of at least one of them. ";
                            msg += "The AgroManagement configuration tested at run-time will ignore this couple.";
                            TraceAgroManagement.TraceEvent(System.Diagnostics.TraceEventType.Warning,
                                102, msg);
                        }
                        break;
                }

                //set rotationLength
                if (sc.Rules.Count > 0)
                {
                    int max = 0;
                    foreach (IRules item in sc.Rules)
                    {
                        if (item.RotationYear >= max)
                            max = item.RotationYear;
                    }
                    intRotationLength = max;
                }

            }
            return sc;
        }

        //TODO: 
        //- change eliminanting the boolean and testing if string is a file name
        //- test if file exist

        /// <summary>
        /// Read planned AgroManagemnt from Xml file
        /// </summary>
        /// <param name="xmlObject"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public SchEvents ReadXMLmanagement(string xmlObject, bool file)
        {
            XmlDocument doc = new XmlDocument();

            FileStream stream = null;
            XmlTextReader tr = null;
            if (file)
            {
                stream = new FileStream(xmlObject, FileMode.Open);
                tr = new XmlTextReader(stream);

                doc.Load(tr);

                stream.Close();
            }
            else
            {
                doc.LoadXml(xmlObject);
            }

            XmlNode root = doc.DocumentElement;

            return ReadXMLmanagement(root);
        }
        #endregion

        #region XML Tags
        /// <summary>
        /// XML tags
        /// </summary>
        public sealed class XML_TAGS
        {
            /// <summary>
            /// tag
            /// </summary>
            public const string AGROMANAGEMENT = "AgroManagement";
            /// <summary>
            /// tag
            /// </summary>
            public const string ACTION = "action";
            /// <summary>
            /// tag
            /// </summary>
            public const string RULE = "rule";
            /// <summary>
            /// tag
            /// </summary>
            public const string IMPACT = "impact";
            /// <summary>
            /// tag
            /// </summary>
            public const string PARAMETER = "parameter";

            /// <summary>
            /// tag
            /// </summary>
            public const string RULE_ASSEMBLY = "assembly";
            /// <summary>
            /// tag
            /// </summary>
            public const string RULE_NAME = "name";

            /// <summary>
            /// tag
            /// </summary>
            public const string IMPACT_ASSEMBLY = "assembly";
            /// <summary>
            /// tag
            /// </summary>
            public const string IMPACT_NAME = "name";

            /// <summary>
            /// tag
            /// </summary>
            public const string PARAMETER_NAME = "name";
            /// <summary>
            /// tag 
            /// </summary>
            public const string PARAMETER_VALUE = "value";
        }
        #endregion

        #region Provide configuration assemblies

        /// <summary>
        /// Provide the list of Rule Assemblies from external libraries.
        /// </summary>
        /// <returns>Array of assemblies as specified in AgroMan.config</returns>
        public Assembly[] getRuleAssemblies()
        {
            return RuleAssemblies.ToArray();
        }

        /// <summary>
        /// Provides the list of Impact Assemblies from external libraries.
        /// </summary>
        /// <returns>Array of assemblies as specified in AgroMan.config</returns>
        public Assembly[] getImpactAssemblies()
        {
            return ImpactAssemblies.ToArray();
        }

        #endregion
    }
}
