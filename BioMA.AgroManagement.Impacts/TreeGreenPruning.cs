using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.ComponentModel;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement.Impacts
{
    public partial class TreeGreenPruning : IManagementTree
    {
        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
        #region Costants

        /// <summary>
        /// Tag for implement element name in xmlMapFile
        /// </summary>
        public const string XML_ELEMENT_NAME = "TreeName";

        /// <summary>
        /// Tag for implement element name in xmlMapFile
        /// </summary>
        public const string XML_ELEMENT_NAME2 = "TreeType";

        /// <summary>
        /// xmlMapFile file name
        /// </summary>
        public const string XML_MAP_FILENAME = "Trees_1.xml";
  
        #endregion

        #region Constructors
        /// <summary>
        /// Instance default constructor
        /// </summary>
        public TreeGreenPruning()
		{
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.TREE_OPERATION;
            _io = new ParametersIO(this);
        }
        #endregion

        #region IManagement Members
        private AManagementTypes.ManagType _managementType;
        /// <summary>
        /// managemnt type from AManagementTypes.cs
        /// </summary>
        public AManagementTypes.ManagType ManagementType
        {
            get { return _managementType; }
        }
        /// <summary>
        /// test of pre-conditions
        /// </summary>
        /// <param name="callID">identifier from caller</param>
        /// <returns>pre-conditions violated</returns>
        public string TestPreconditions(string callID)
        {
            return VerifyPreconditions(callID);
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
                    case ("TreeName"):
                        _treeName = child.Attributes["value"].InnerText;
                        break;
					case ("TreeType"):
						_treeType = child.Attributes["value"].InnerText;
						break;
                    case ("TreeOperation"):
                        _treeOperation = child.Attributes["value"].InnerText;
                        break;
                    case ("ResidualLAI"):
                        _residualLAI = double.Parse(child.Attributes["value"].InnerText);
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
            writer.WriteAttributeString("name","TreeName");
            writer.WriteAttributeString("value", _treeName.ToString());
            writer.WriteEndElement();
			
			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","TreeType");
			writer.WriteAttributeString("value", _treeType.ToString());
			writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "TreeOperation");
            writer.WriteAttributeString("value", _treeOperation.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "ResidualLAI");
            writer.WriteAttributeString("value", _residualLAI.ToString());
            writer.WriteEndElement();
        }
        #endregion

        #endregion

        #region IManagementTree Members
        private string _treeName;			           
        /// <summary>
        /// Crop name
        /// </summary>
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.TreeGreenPruning", "TreeNameMap")]
        [TypeConverter(typeof(DictionaryConverter))]
        public string TreeName
        {
            get { return _treeName; }
            set { _treeName = value; }
        }

        private ImpactMap _treeNameMap = null;
        /// <summary>
        /// Map to associate enum value to its description
        /// </summary>
        [Browsable(false)]
        public ImpactMap TreeNameMap
        {
            get
            {
                if (_treeNameMap == null)
                {
                    _treeNameMap = new ImpactMap
                        (TreeStart.XML_MAP_FILENAME,
                         TreeStart.XML_ELEMENT_NAME);
                }
                return _treeNameMap;
            }
        }

        private string _treeType;
        /// <summary>
        /// Crop name
        /// </summary>
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.TreeGreenPruning", "TreeTypeMap")]
        [TypeConverter(typeof(DictionaryConverter))]
        public string TreeType
        {
            get { return _treeType; }
            set { _treeType = value; }
        }

        private ImpactMap _treeTypeMap = null;
        /// <summary>
        /// Map to associate enum value to its description
        /// </summary>
        [Browsable(false)]
        public ImpactMap TreeTypeMap
        {
            get
            {
                if (_treeTypeMap == null)
                {
                    _treeTypeMap = new ImpactMap
                        (TreeGreenPruning.XML_MAP_FILENAME,
                         TreeGreenPruning.XML_ELEMENT_NAME2);
                }
                return _treeTypeMap;
            }
        }

        private string _treeOperation;
        /// <summary>
        /// Type of tree operation
        /// </summary>
        public string TreeOperation
        {
            get { return _treeOperation; }
            set { _treeOperation = value; }
        }

        #endregion
	    
        #region Specific parameters

        private double _residualLAI;
        /// <summary>
        /// LAI residual after pruning
        /// </summary>
        public double ResidualLAI
        {
            get { return _residualLAI; }
            set { _residualLAI = value; }
        }

        #endregion

        public IList<string> StrategyUsed
        {
            get { return new List<string>(); }
        }

	    #region Implementation of IDomainClass

	    private readonly ParametersIO _io;
	    public IDictionary<string, PropertyInfo> PropertiesDescription
	    {
	        get {

                return _io.GetCachedProperties(typeof(IDomainClass));
            }
	    }

        public bool ClearValues()
        {
            return true;
        }

        #endregion
    }
}
