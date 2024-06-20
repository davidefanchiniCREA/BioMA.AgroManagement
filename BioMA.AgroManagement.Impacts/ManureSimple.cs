using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using CRA.ModelLayer.Core;
using CRA.AgroManagement;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Data-type to model organic nitrogen application according to the 
	/// ManureSimple model
	/// </summary>
	public partial class ManureSimple : IManagementManure
    {
        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }

        #region Costants

        // No property linked to an external XML list in this impact

        #endregion

        #region Constructors
        /// <summary>
		/// Instance default constructor
		/// </summary>
        public ManureSimple()
		{
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.ORGANIC_FERTILIZATION;
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
					case ("TotalAmount"):
						_totalAmount = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("DryMatterFraction"):
						_dryMatterFraction = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("SurfaceBroadcast"):
						_surfaceBroadcast = bool.Parse(child.Attributes["value"].InnerText);
						break;
                    case ("NH4PercentageContent"):
                        _AmmoniaPercentageContent = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("NOrganicPercentageContent"):
                        _NOrganicPercentageContent = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("POnOrganicMatrixPercentageContent"):
                        _POnOrganicMatrixPercentageContent = double.Parse(child.Attributes["value"].InnerText);
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
			writer.WriteAttributeString("name","TotalAmount");
			writer.WriteAttributeString("value", _totalAmount.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","DryMatterFraction");
			writer.WriteAttributeString("value", _dryMatterFraction.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","SurfaceBroadcast");
			writer.WriteAttributeString("value", _surfaceBroadcast.ToString());
			writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "NH4PercentageContent");
            writer.WriteAttributeString("value", _AmmoniaPercentageContent.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "NOrganicPercentageContent");
            writer.WriteAttributeString("value", _NOrganicPercentageContent.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "POnOrganicMatrixPercentageContent");
            writer.WriteAttributeString("value", _POnOrganicMatrixPercentageContent.ToString());
            writer.WriteEndElement();

		}
		#endregion

		#endregion

        #region IManagementManure Members
        private double _totalAmount;
		/// <summary>
		/// Total amount of organic fertilizer
		/// </summary>
		public double TotalAmount
		{
			get { return _totalAmount; }
			set { _totalAmount = value;	}
		}
        private double _dryMatterFraction;
		/// <summary>
		/// Dry matter fraction of the organic fertilizer applied
		/// </summary>
		public double DryMatterFraction
		{
			get { return _dryMatterFraction; }
			set { _dryMatterFraction = value; }
		}
        private bool _surfaceBroadcast;
		/// <summary>
		/// Surface broadcast of fertilizer
		/// </summary>
		public bool SurfaceBroadcast
		{
			get { return _surfaceBroadcast; }
			set { _surfaceBroadcast = value; }
		}
 
		#endregion

        #region Specific parameters
        private double _AmmoniaPercentageContent;
        /// <summary>
        /// Percentage content of ammonia
        /// </summary>
        public double AmmoniaPercentageContent
        {
            get { return _AmmoniaPercentageContent; }
            set { _AmmoniaPercentageContent = value; }
        }

        private double _NOrganicPercentageContent;
        /// <summary>
        /// Percentage content of organic nitrogen
        /// </summary>
        public double NOrganicPercentageContent
        {
            get { return _NOrganicPercentageContent; }
            set { _NOrganicPercentageContent = value; }
        }

        private double _POnOrganicMatrixPercentageContent;
        /// <summary>
        /// Percentage content of phosporus on organic matrix 
        /// </summary>
        public double POnOrganicMatrixPercentageContent
        {
            get { return _POnOrganicMatrixPercentageContent; }
            set { _POnOrganicMatrixPercentageContent = value; }
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
