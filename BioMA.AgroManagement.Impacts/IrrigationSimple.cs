using System;
using System.Xml;
using CRA.ModelLayer.Core;
using CRA.AgroManagement;

using System.ComponentModel;
using System.Xml.Schema;
using System.Collections.Generic;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Data-type to model irrigation according to the IrrigationSimple model
	/// </summary>
	public partial class IrrigationSimple : IManagementIrrigation
	{

		public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
		#region Constants

		/// <summary>
		/// Tag for pesticide chemical element name in xmlMapFile
		/// </summary>
		public const string XML_ELEMENT_NAME = "IrrigationType";

		/// <summary>
		/// xmlMapFile file name
		/// </summary>
		public const string XML_MAP_FILENAME = "IrrigationSimple.xml";

		#endregion

        #region Constructors
        /// <summary>
		/// Instance default onstructor
		/// </summary>
		public IrrigationSimple() 	
		{
			SetParameterDescription();
			_managementType = AManagementTypes.ManagType.IRRIGATION;
            _io = new ParametersIO(this);
        }
        #endregion

		#region IManagement

		private AManagementTypes.ManagType _managementType;   //from IManagemnt
        /// <summary>
        /// managemnt type from AManagementTypes.cs
        /// </summary>
        public AManagementTypes.ManagType ManagementType
		{
			get {return _managementType;}
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
					case ("IrrigationVolume"):
						IrrigationVolume = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("IrrigationType"):
						IrrigationType = child.Attributes["value"].InnerText;
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
			writer.WriteAttributeString("name","IrrigationVolume");
			writer.WriteAttributeString("value",IrrigationVolume.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","IrrigationType");
			writer.WriteAttributeString("value",IrrigationType.ToString());
			writer.WriteEndElement();
		}
		#endregion

		#endregion		

        #region IManagementIrrigation

        private double _irrigationVolume;      
		/// <summary>
		/// Irrigation volume
		/// </summary>
		public double IrrigationVolume
		{
			get {return _irrigationVolume;}
			set {_irrigationVolume = value;}
		}

		#endregion

		#region Specific parameters

		private string _irrigationType;
		/// <summary>
        /// Irrigation type
		/// </summary>
		/// MD 17/06/2014 To be verified: changed first string in case it refers to the DLL name 
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.IrrigationSimple", "IrrigationTypeMap")]
        [TypeConverter(typeof(DictionaryConverter))]
		public string IrrigationType
		{
		    get { return _irrigationType; }
		    set { _irrigationType = value;  }
		}

        private ImpactMap _irrigationTypeMap = null;
		/// <summary>
        /// Map to associate enum value to its description
		/// </summary>
        //[Browsable( false )]
        public ImpactMap IrrigationTypeMap
        {
            get
            {
                if (_irrigationTypeMap == null)
                {
                    _irrigationTypeMap = new ImpactMap
                        (IrrigationSimple.XML_MAP_FILENAME, 
                         IrrigationSimple.XML_ELEMENT_NAME);
                }
                return _irrigationTypeMap;
            }
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
            get
            {

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
