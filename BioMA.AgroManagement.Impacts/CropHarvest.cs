using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.ComponentModel;

using CRA.ModelLayer.Core;
using CRA.AgroManagement;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Parameters for crop harvest
	/// </summary>
	public partial class CropHarvest : IManagementCrop
    {
        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
        #region Costants

        /// <summary>
        /// Tag for implement element name in xmlMapFile
        /// </summary>
        public const string XML_ELEMENT_NAME = "CropName";

        /// <summary>
        /// xmlMapFile file name
        /// </summary>
        public const string XML_MAP_FILENAME = "Crops_1.xml";
        
        #endregion

        #region Constructors
        /// <summary>
        /// Instance default constructor
        /// </summary>
        public CropHarvest()
		{
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.CROP_OPERATION;
            _io = new ParametersIO(this);
        }
        #endregion

        #region IManagement Members

        private AManagementTypes.ManagType _managementType;	//from IManagement
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
                    case ("CropName"):
                        _cropName = child.Attributes["value"].InnerText;
                        break;
                    case ("CropOperation"):
                        _cropOperation = child.Attributes["value"].InnerText;
                        break;
                    case ("YieldLossFraction"):
                        _yieldLossFraction = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("ResidualRemovalFraction"):
                        _residualRemovalFraction = double.Parse(child.Attributes["value"].InnerText);
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
            writer.WriteAttributeString("name","CropName");
            writer.WriteAttributeString("value", _cropName);
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "CropOperation");
            writer.WriteAttributeString("value", _cropOperation);
            writer.WriteEndElement();			

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name","YieldLossFraction");
            writer.WriteAttributeString("value", _yieldLossFraction.ToString());
            writer.WriteEndElement();
 
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name","ResidualRemovalFraction");
            writer.WriteAttributeString("value", _residualRemovalFraction.ToString());
            writer.WriteEndElement();
        }
        #endregion

        #endregion

        #region IManagementCrop Members

        private string _cropName;			            
        /// <summary>
        /// Crop name
        /// </summary>
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.CropHarvest", "CropNameMap")]
        [TypeConverter(typeof(DictionaryConverter))]
        public string CropName
        {
            get { return _cropName; }
            set { _cropName = value; }
        }

        private ImpactMap _cropNameMap = null;
        /// <summary>
        /// Map to associate enum value to its description
        /// </summary>
        [Browsable(false)]
        public ImpactMap CropNameMap
        {
            get
            {
                if (_cropNameMap == null)
                {
                    _cropNameMap = new ImpactMap
                        (CropHarvest.XML_MAP_FILENAME,
                         CropHarvest.XML_ELEMENT_NAME);
                }
                return _cropNameMap;
            }
        }

        private string _cropOperation;					
        /// <summary>
        /// Crop operation type
        /// </summary>
        public string CropOperation
        {
            get { return _cropOperation; }
            set { _cropOperation = value; }
        }
        #endregion
        
        #region Specific parameters
        private double _yieldLossFraction;
        /// <summary>
        /// Yield loss at harvest
        /// </summary>
        public double YieldLossFraction
        {
            get {return _yieldLossFraction;}
            set {_yieldLossFraction = value;}
        }

        private double _residualRemovalFraction;
        /// <summary>
        /// Residual removal at harvest
        /// </summary>
        public double ResidualRemovalFraction
        {
            get {return _residualRemovalFraction;}
            set {_residualRemovalFraction = value;}
        }

        #endregion

        public IList<string> StrategyUsed
        {
            get { return new List<string>(); }
        }

        public bool ClearValues()
        {
            return true;
        }

        #region Implementation of IDomainClass

        private readonly ParametersIO _io;
        public IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {

                return _io.GetCachedProperties(typeof(IDomainClass));
            }
        }

        #endregion
    }
}
