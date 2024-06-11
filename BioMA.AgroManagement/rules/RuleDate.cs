using System;
using System.Xml;
using System.Collections.Generic;

using CRA.AgroManagement;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;

namespace CRA.AgroManagement.Rules
{
	/// <summary>
	/// Triggers event when a relative date and rotation year is reached.
	/// </summary>
	public class RuleDateEx : IRules
	{
        public string TestPreconditionsOnParameters(string callID) {
            return "";
        }

        private ITestsOutput _preconditionsWriter;

		public ITestsOutput PreconditionsWriter
        {
			get
            {
				return _preconditionsWriter;
            }

			set
            {
				_preconditionsWriter = value;
				foreach (IStrategy strategy in this.GetAllPossibleAssociatedStrategies())
                {
					strategy.PreconditionsWriter = _preconditionsWriter;
                }
            }
        }

		static RuleDateEx()
		{
			FillInOutParLists();
			SetParameterDescription();
		}

        public RuleDateEx()
        {
            ModellingOptions mo = new ModellingOptions(new List<VarInfo> { _relativeDateVarInfo, _rotationYearVarInfo },
         new List<PropertyDescription>(), new List<PropertyDescription>(), new List<string>());
            _modellingOptionsManager = new ModellingOptionsManager(mo);
        }

	    #region Lists: Inputs, Parameters, Description
        private static string _modelDescription =
            "Trigger crop management based on: relative date and rotation year";
        /// <summary>Model summary description/// </summary>
	    public static string modelDescription
        {
            get {return _modelDescription; } 
        } 
       
        private static List<string> _inputs = new List<string>();
        private static List<string> _parameters = new List<string>();
        private static List<string> _outputs = new List<string>();

        /// <summary>list of inputs</summary>
		public static List<string> Inputs 
		{
			get {return _inputs;}
		}
		/// <summary>list of parameters</summary>
		public static List<string> Parameters
		{
			get {return _parameters;}
		}
		/// <summary>list of outputs</summary>
		public static List<string> Outputs
		{
			get {return _outputs;}
		}
		#endregion

		#region Parameters
		//values
		private int _relativeDate = 1;
		private int _rotationYear = 1;
		private static VarInfo _relativeDateVarInfo = new VarInfo();
		private static VarInfo _rotationYearVarInfo = new VarInfo();
		
		/// <summary>
		/// Relative date to trigger rule
		/// </summary>
		public int RelativeDate
		{
			get {return _relativeDate; }
			set {_relativeDate = value; }
		}
		/// <summary>
		/// Rotation year to be matched
		/// </summary>
		public int RotationYear
		{
			get {return _rotationYear; }
			set {_rotationYear = value; }
		}        
		//VarInfo properties
		/// <summary>
		/// VarInfo of relative date to be matched
		/// </summary>
		public static VarInfo RelativeDateVarInfo
		{
			get {return _relativeDateVarInfo; }
		}
		/// <summary>
		/// VarInfo of rotation year to be matched
		/// </summary>
		public static VarInfo RotationYearVarInfo
		{
			get {return _rotationYearVarInfo; }
		}
		#endregion
       
	    #region IStrategy Members

        /// <summary>
        /// Trigger an event based on the day of the year of the rotation year.
        /// </summary>
        public string Description
        {
			get { return "Trigger an event based on the day of the year of the rotation year"; }
        }

        /// <summary>
        /// Description on the knowledge base.
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public string URL
        {
            //get { return "http://www.apesimulator.org/ontologybrowser.aspx"; }
            get { return "http://www.biomamodelling.org/Domains.aspx"; }
        }

	  

	    #endregion

        #region IVarInfoClass Members

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "StatesAgroMan"; }
        }

        #endregion

		#region IRules members
		/// <summary>
		/// impact to be coupled to the rule
		/// </summary>
		public string ImpactDependency
		{
			get { return String.Empty; }
		}

		/// <summary>
		/// Apply crop management based on relative date and rotation year.
		/// </summary>
		/// <param name="st">biophysical states of the system</param>
		/// <param name="m">management parameters</param>
		/// <returns>true is rules are matched</returns>
		public bool CheckRule(StatesAgroMan st, IManagement m)
		{
			bool testRule = false;
			if (_relativeDate == st.CurrentDay &  
				_rotationYear == st.RotationYear)
			{
				testRule = true;
			}
			return testRule;        
		}

		/// <summary>
        /// Test if rule inputs respect pre-conditions.
		/// </summary>
		/// <param name="m">management parameters</param>
		/// <param name="callID">an ID from caller</param>
		public string TestPreConditions(IManagement m, string callID)
		{
			string result;
			//test preconditions of this rule
			result = VerifyPreconditions(callID);
			result += m.TestPreconditions(callID);
			return result;
		}

		#region Xml management
		/// <summary>
		/// Reads management content from a XmlNode
		/// </summary>
		/// <param name="node">xml node containing instance data</param>
		public void LoadXml(XmlNode node)
		{
			foreach(XmlNode child in node.ChildNodes)
			{
				switch (child.Attributes["name"].InnerText)
				{
					case ("RelativeDate"):
						RelativeDate = int.Parse(child.Attributes["value"].InnerText);
						break;
					case ("RotationYear"):
						RotationYear = int.Parse(child.Attributes["value"].InnerText);
						break;
				}			
			}
		}

		/// <summary>
		/// Stores actual data in a passed xml file
		/// </summary>
		/// <param name="writer"></param>
		public void SaveXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","RelativeDate");
			writer.WriteAttributeString("value",RelativeDate.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","RotationYear");
			writer.WriteAttributeString("value",RotationYear.ToString());
			writer.WriteEndElement();	
		}
		#endregion

		#endregion

		#region Preconditions
		private string VerifyPreconditions(string callID)
		{
			SetParametersInputsCurrentValue();
            /* 29/05/2012 old preconditions API - begin */
            //CRA.Core.Preconditions.PreconditionsData prc = new CRA.Core.Preconditions.PreconditionsData();
            //CRA.Core.Preconditions.Preconditions pre = new CRA.Core.Preconditions.Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_relativeDateVarInfo);
            //prc.RangeBased.Add(_rotationYearVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.dll, class RuleRelativeDate"); }
            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();

            
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_relativeDateVarInfo));
            prc.AddCondition(new RangeBasedCondition(_rotationYearVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.dll, class RuleRelativeDate"); }

            /* 29/05/2012 new preconditions API - end */
			return result;
		}
		private void SetParametersInputsCurrentValue()
		{
			_relativeDateVarInfo.CurrentValue = _relativeDate;
			_rotationYearVarInfo.CurrentValue = _rotationYear;
		}
		#endregion
		
		#region  Constructor
		private static void SetParameterDescription()
		{
			_relativeDateVarInfo.Description = "Day of the year";
			_relativeDateVarInfo.Name = "RelativeDate";
			_relativeDateVarInfo.MaxValue = 366;
			_relativeDateVarInfo.MinValue = 1;
			_relativeDateVarInfo.DefaultValue = 180;
			_relativeDateVarInfo.VarType = VarInfo.Type.PARAMETER;
			_relativeDateVarInfo.Units = "d";
		    _relativeDateVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

			_rotationYearVarInfo.Description = "Rotation year when management must be applied";
			_rotationYearVarInfo.Name = "RotationYear";
			_rotationYearVarInfo.MaxValue = 10;
			_rotationYearVarInfo.MinValue = 1;
			_rotationYearVarInfo.DefaultValue = 1;
			_rotationYearVarInfo.VarType = VarInfo.Type.PARAMETER;
			_rotationYearVarInfo.Units = "unitless";
            _rotationYearVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
		}

		private static void FillInOutParLists()
		{
			//inputs
			_inputs.Add("CurrentDay");
			_inputs.Add("RotationYear");

			//parameters
			_parameters.Add("RelativeDate");
			_parameters.Add("RotationYear");

			//outputs
			_outputs.Add("true/false");
		}
		#endregion

        #region Implementation of IStrategy

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>();
        }

        public bool IsContext
        {
            get { return false; }
        }

        public IList<int> TimeStep
        {
            get { return new List<int>(); }
        }

        public string ModelType
        {
            get { return "AgromanagementRule"; }
        }

        public string Domain
        {
            get { return "Agromanagement"; }
        }

        public CRA.ModelLayer.MetadataTypes.PublisherData PublisherData
        {
            get { return new ModelLayer.MetadataTypes.PublisherData(); }
        }

        private ModellingOptionsManager _modellingOptionsManager;

        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; }
        }

        #endregion
    }
}
