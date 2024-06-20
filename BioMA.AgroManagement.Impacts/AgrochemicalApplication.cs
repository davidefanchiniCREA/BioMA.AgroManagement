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
    /// Data-type to model agrochemical application according to the AgrochemicalApplication model
    /// </summary>
    public partial class AgrochemicalApplication : IManagementPesticides
    {
        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
        #region Constants


        /// <summary>
        /// Tag for Pesticide type structure name
        /// </summary>
        public const string XML_TAG = "Agrochemical";

        /// <summary>
        /// Tag for pesticide chemical element name in xmlMapFile
        /// </summary>
        public const string XML_ELEMENT_NAME = "Agrochemical";



        #endregion

        #region Constructors

        /// <summary>
        /// Instance default constructor
        /// </summary>
        public AgrochemicalApplication()
        {
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.PESTICIDE;
            _io = new ParametersIO(this);
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

        #endregion

        #region IManagement members

        private AManagementTypes.ManagType _managementType;	//from IManagement
        /// <summary>
        /// Management type from CRA.AgroManagement.AManagementTypes.cs
        /// </summary>
        public AManagementTypes.ManagType ManagementType
        {
            get { return _managementType; }
        }


        #endregion

        #region IManagementPesticides

        //No method in the interface currently

        #endregion


        public IList<string> StrategyUsed
        {
            get { return new List<string>(); }
        }




        #region Specific parameters

        private string _agrochemicalName;
        public string AgrochemicalName
        {
            get { return _agrochemicalName; }
            set { _agrochemicalName = value; }
        }


        private double _agrochemicalDosePercentage;
        /// <summary>
        /// Amount of chemical applied
        /// </summary>
        public double AgrochemicalDosePercentage
        {
            get { return _agrochemicalDosePercentage; }
            set { _agrochemicalDosePercentage = value; }
        }

        private double _degradationRate;
        /// <summary>
        /// Degradation rate
        /// </summary>
        public double DegradationRate
        {
            get { return _degradationRate; }
            set { _degradationRate = value; }
        }

        private double _tenacityFactor;
        /// <summary>
        /// TenacityFactor
        /// </summary>
        public double TenacityFactor
        {
            get { return _tenacityFactor; }
            set { _tenacityFactor = value; }
        }

        private double _agrochemicalEfficacy;
        /// <summary>
        /// AgrochemicalEfficacy
        /// </summary>
        public double AgrochemicalEfficacy
        {
            get { return _agrochemicalEfficacy; }
            set { _agrochemicalEfficacy = value; }
        }

        private double _aShapeParameter;
        /// <summary>
        /// AShapeParameter
        /// </summary>
        public double AShapeParameter
        {
            get { return _aShapeParameter; }
            set { _aShapeParameter = value; }
        }

        private double _bShapeParameter;
        /// <summary>
        /// AShapeParameter
        /// </summary>
        public double BShapeParameter
        {
            get { return _bShapeParameter; }
            set { _bShapeParameter = value; }
        }

        #endregion

        #region Xml management
        /// <summary>
        /// Reads management content from a XmlNode
        /// </summary>
        /// <param name="node">xml node containing instance data</param>
        public void LoadXml(XmlNode node)
        {
            ////TODO: change to load from complextype within the node
            //foreach (XmlNode complex in node.ChildNodes)
            //{

            foreach (XmlNode child in node.ChildNodes)
            {
                switch (child.Attributes["name"].InnerText)
                {
                    case ("AgrochemicalName"):
                        _agrochemicalName = child.Attributes["value"].InnerText;
                        break;
                    case ("AgrochemicalDosePercentage"):
                        _agrochemicalDosePercentage = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("DegradationRate"):
                        _degradationRate = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("TenacityFactor"):
                        _tenacityFactor = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("AgrochemicalEfficacy"):
                        _agrochemicalEfficacy = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("AShapeParameter"):
                        _aShapeParameter = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("BShapeParameter"):
                        _bShapeParameter = double.Parse(child.Attributes["value"].InnerText);
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
            //pesticideAmount
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "AgrochemicalName");
            writer.WriteAttributeString("value", _agrochemicalName);
            writer.WriteEndElement();
            //AgrochemicalDosePercentage
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "AgrochemicalDosePercentage");
            writer.WriteAttributeString("value", _agrochemicalDosePercentage.ToString());
            writer.WriteEndElement();
            //DegradationRate
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "DegradationRate");
            writer.WriteAttributeString("value", _degradationRate.ToString());
            writer.WriteEndElement();
            //TenacityFactor
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "TenacityFactor");
            writer.WriteAttributeString("value", _tenacityFactor.ToString());
            writer.WriteEndElement();
            //AgrochemicalEfficacy
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "AgrochemicalEfficacy");
            writer.WriteAttributeString("value", _agrochemicalEfficacy.ToString());
            writer.WriteEndElement();
            //AShapeParameter
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "AShapeParameter");
            writer.WriteAttributeString("value", _aShapeParameter.ToString());
            writer.WriteEndElement();
            //BShapeParameter
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "BShapeParameter");
            writer.WriteAttributeString("value", _bShapeParameter.ToString());
            writer.WriteEndElement();


            //End ComplexParameter tag
            writer.WriteEndElement();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Pesticide data-type name
        /// </summary>
        /// <returns></returns>
        //public override string ToString()
        //{
        //    return "Application: " + this._agrochemicalName;
        //}

        #endregion

        public bool ClearValues()
        {
            return true;
        }
    }

}



      
