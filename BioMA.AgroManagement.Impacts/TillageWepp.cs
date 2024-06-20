using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;

using CRA.ModelLayer.Core;
using CRA.AgroManagement;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Data-type to model tillage according to the Wepp model.
	/// </summary>
	public partial class TillageWepp : IManagementTillage
	{
		public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
		#region Constants

		/// <summary>
		/// Tag for implement element name in xmlMapFile
		/// </summary>
		public const string XML_ELEMENT_NAME = "Implement";

        /// <summary>
        /// xmlMapFile file name
        /// </summary>
        public const string XML_MAP_FILENAME = "TillageWepp.xml";

        #endregion

        #region Constructors
        /// <summary>
		/// Instance default onstructor
		/// </summary>
		public TillageWepp() 	
		{
			SetParameterDescription();
			_managementType = AManagementTypes.ManagType.TILLAGE;
            _io = new ParametersIO(this);
        }
        #endregion

		#region IManagementTillage members
        private double _meanTillageDepth;					//from IManagementTillage
		/// <summary>
		/// Mean depth from surface of tillage event
		/// </summary>
		public double MeanTillageDepth
		{
			get {return _meanTillageDepth;}
			set {_meanTillageDepth = value;}
		}

		#endregion

		#region IManagement members
        private AManagementTypes.ManagType _managementType;	//from IManagement
        /// <summary>
        /// managemnt type from AManagementTypes.cs
        /// </summary>
        public AManagementTypes.ManagType ManagementType
		{
			get {return _managementType;}
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
					case ("MeanTillageDepth"):
						_meanTillageDepth = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("Implement"):
						_implement =  child.Attributes["value"].InnerText;
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
			writer.WriteAttributeString("name", "MeanTillageDepth");
			writer.WriteAttributeString("value", _meanTillageDepth.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement( "parameter" );
			writer.WriteAttributeString( "name", "Implement" );
			writer.WriteAttributeString( "value", Implement.ToString() );
			writer.WriteEndElement();
		}
		#endregion

		#endregion

        #region Specific parameters
        
        private string _implement;
        /// <summary>
        /// Type of implemnt according to the Wepp approach
        /// </summary>
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.TillageWepp", "ImplementMap")]
        [TypeConverter(typeof(DictionaryConverter))]
        public string Implement
        {
            get { return _implement; }
            set { _implement = value; }
        }

        private ImpactMap _implementMap = null;
        /// <summary>
        /// Map to associate enum value to its description
        /// </summary>
        [Browsable(false)]
        public ImpactMap ImplementMap
        {
            get
            {
                if (_implementMap == null)
                {
                    _implementMap = new ImpactMap
                        (TillageWepp.XML_MAP_FILENAME,
						 TillageWepp.XML_ELEMENT_NAME );
                }
                return _implementMap;
            }
        }


        #endregion
    }
}
