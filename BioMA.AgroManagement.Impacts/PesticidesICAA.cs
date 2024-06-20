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
    /// Data-type to model pesticide spray according to the PesticideICAA model
    /// </summary>
    public partial class PesticidesICAA : IManagementPesticides
    {
        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
        #region Constants

        /// <summary>
        /// Tag for complex parameter structure
        /// </summary>
        public const string XML_COMPLEX_PARAMETER = "ComplexParameter";

        /// <summary>
        /// Tag for Pesticide type structure name
        /// </summary>
        public const string XML_TAG = "Pesticide";

        /// <summary>
        /// Tag for pesticide chemical element name in xmlMapFile
        /// </summary>
        public const string XML_ELEMENT_NAME = "PesticideChemicals";

        /// <summary>
        /// xmlMapFile file name
        /// </summary>
        public const string XML_MAP_FILENAME = "PesticidesICAA.xml";

        #endregion

        #region Constructors

        /// <summary>
        /// Instance default constructor
        /// </summary>
        public PesticidesICAA()
        {
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.PESTICIDE;
            _io= new ParametersIO(this);
        }

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

        #region Xml management
        /// <summary>
        /// Read management content from a XmlNode
        /// </summary>
        /// <param name="node">xml node containing instance data</param>
        public void LoadXml(XmlNode node)
        {
            Pesticide p = null;
            _agroChemicals.Clear();

            foreach (XmlNode child in node.ChildNodes)
            {
                //Pesticide structure load
                if (child.Name == PesticidesICAA.XML_COMPLEX_PARAMETER &&
                    child.Attributes["name"].Value == PesticidesICAA.XML_TAG)
                {
                    p = new Pesticide();
                    p.LoadXml(child);
                    _agroChemicals.Add(p);
                }

                //load here other parameters if any
            }
        }

        /// <summary>
        /// Stores actual data in a passed xml file
        /// </summary>
        /// <param name="writer"></param>
        public void SaveXml(XmlTextWriter writer)
        {
            foreach (Pesticide p in _agroChemicals)
            {
                p.SaveXml(writer);
            }

        }
        #endregion

        #endregion

        #region IManagementPesticides

        //No method in the interface currently

        #endregion

        #region Specific parameters

        private List<Pesticide> _agroChemicals = new List<Pesticide>();
        /// <summary>
        /// AgroChemicals 
        /// </summary>
        public List<Pesticide> AgroChemicals
        {
            get { return _agroChemicals; }
            set { _agroChemicals = value; }
        }

		private ImpactMap _pesticideChemicalsMap = null;
        /// <summary>
        /// Map to associate enum value to its description
        /// </summary>
		[Browsable( false )]
        public ImpactMap PesticideChemicalsMap
		{
			get
			{
				if (_pesticideChemicalsMap == null)
					_pesticideChemicalsMap = new ImpactMap
						( PesticidesICAA.XML_MAP_FILENAME, 
                        PesticidesICAA.XML_ELEMENT_NAME );

				return _pesticideChemicalsMap;
			}
		}

        #endregion

        public IList<string> StrategyUsed
        {
            get { return new List<string>(); }
        }

        /// <summary>
        /// Data-type for pesticides
        /// </summary>
        public partial class Pesticide
        {

            #region Constructor
            
            /// <summary>
            /// Data-type for pesticide
            /// </summary>
            public Pesticide()
            {
                SetParameterDescription();
            }
            
            #endregion

            #region Specific parameters

            private string _pesticideChemical;
            /// <summary>
            /// Type of chemical applied
            /// </summary>
			[ImpactMap( "CRA.AgroManagement2014.Impacts", "CRA.AgroManagement.Impacts.PesticidesICAA", "PesticideChemicalsMap" )]
			[TypeConverter( typeof( DictionaryConverter ) )]
            public string PesticideChemical
            {
                get { return _pesticideChemical; }
                set { _pesticideChemical = value; }
            }

            private ImpactMap _pesticideChemicalsMap = null;
            /// <summary>
            /// Map to associate enum value to its description
            /// </summary>
            [Browsable(false)]
            public ImpactMap PesticideChemicalsMap
            {
                get
                {
                    if (_pesticideChemicalsMap == null)
                        _pesticideChemicalsMap = new ImpactMap
                            (PesticidesICAA.XML_MAP_FILENAME,
                            PesticidesICAA.XML_ELEMENT_NAME);

                    return _pesticideChemicalsMap;
                }
            }

            private double _pesticideAmount;
            /// <summary>
            /// Amount of chemical applied
            /// </summary>
            public double PesticideAmount
            {
                get { return _pesticideAmount; }
                set { _pesticideAmount = value; }
            }

            private double _fractionChemical;
            /// <summary>
            /// Fraction of the amount in chemical applied
            /// </summary>
            public double FractionChemical
            {
                get { return _fractionChemical; }
                set { _fractionChemical = value; }
            }

            #endregion

            #region Xml management
            /// <summary>
            /// Reads management content from a XmlNode
            /// </summary>
            /// <param name="node">xml node containing instance data</param>
            internal void LoadXml(XmlNode node)
            {
				////TODO: change to load from complextype within the node
				//foreach (XmlNode complex in node.ChildNodes)
				//{
					if (node.Name == "ComplexParameter")
					{
						foreach (XmlNode child in node.ChildNodes)
						{
							switch (child.Attributes["name"].InnerText)
							{
								case ("PesticideAmount"):
									_pesticideAmount = double.Parse( child.Attributes["value"].InnerText );
									break;
								case ("FractionChemical"):
									_fractionChemical = double.Parse( child.Attributes["value"].InnerText );
									break;
								case ("PesticideChemical"):
									_pesticideChemical = child.Attributes["value"].InnerText;
									break;
							}
						}
					}
				//}
            }

            /// <summary>
            /// Stores actual data in a passed xml file
            /// </summary>
            /// <param name="writer"></param>
            internal void SaveXml(XmlTextWriter writer)
            {
                //start ComplexParameter tag
                writer.WriteStartElement(PesticidesICAA.XML_COMPLEX_PARAMETER);
                writer.WriteAttributeString("name", PesticidesICAA.XML_TAG);
                //pesticideAmount
                writer.WriteStartElement("parameter");
                writer.WriteAttributeString("name", "PesticideAmount");
                writer.WriteAttributeString("value", _pesticideAmount.ToString());
                writer.WriteEndElement();
                //fractionChemical
                writer.WriteStartElement("parameter");
                writer.WriteAttributeString("name", "FractionChemical");
                writer.WriteAttributeString("value", _fractionChemical.ToString());
                writer.WriteEndElement();
                //pesticideName
                writer.WriteStartElement("parameter");
                writer.WriteAttributeString("name", "PesticideChemical");
                writer.WriteAttributeString("value", _pesticideChemical.ToString());
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
            public override string ToString()
            {
                return "Application: " + this._pesticideChemical;
            }

            #endregion

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
