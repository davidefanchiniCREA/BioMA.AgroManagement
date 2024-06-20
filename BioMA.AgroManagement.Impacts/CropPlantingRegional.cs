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
    /// CropPlanting implements a simple set of parameters to plant a crop,
    /// and it included an ID code for regionalization 
    /// </summary>
    public partial class CropPlantingRegional : IManagementCrop
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
        public CropPlantingRegional()
        {
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.CROP_OPERATION;
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
            foreach (XmlNode child in node.ChildNodes)
            {
                switch (child.Attributes["name"].InnerText)
                {
                    case ("CropName"):
                        _cropName = child.Attributes["value"].InnerText;
                        break;
                    case ("CropOperation"):
                        _cropOperation = child.Attributes["value"].InnerText;
                        break;
                    case ("PlantingDepth"):
                        _plantingDepth = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("CropRegionalID"):
                        _CropRegionalID = int.Parse(child.Attributes["value"].InnerText);
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
            writer.WriteAttributeString("name", "CropName");
            writer.WriteAttributeString("value", _cropName);
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "CropOperation");
            writer.WriteAttributeString("value", _cropOperation);
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "PlantingDepth");
            writer.WriteAttributeString("value", _plantingDepth.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "CropRegionalID");
            writer.WriteAttributeString("value", _CropRegionalID.ToString());
            writer.WriteEndElement();

        }
        #endregion

        #endregion

        #region IManagementCrop Members
        private string _cropName;
        /// <summary>
        /// Crop name
        /// </summary>
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.CropPlantingRegional", "CropNameMap")]
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
                        (CropPlanting.XML_MAP_FILENAME,
                         CropPlanting.XML_ELEMENT_NAME);
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

        private double _plantingDepth;
        /// <summary>
        /// Planting depth
        /// </summary>
        public double PlantingDepth
        {
            get { return _plantingDepth; }
            set { _plantingDepth = value; }
        }

        private int _CropRegionalID;
        /// <summary>
        /// Regional code for crop parameters
        /// </summary>
        public int CropRegionalID
        {
            get { return _CropRegionalID; }
            set { _CropRegionalID = value; }
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
