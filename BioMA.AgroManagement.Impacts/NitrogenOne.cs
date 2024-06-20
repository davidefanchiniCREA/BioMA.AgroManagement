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
	/// Data-type to model mineral nitrogen application according to the NitrogenOne model
	/// </summary>
	public partial class NitrogenOne : IManagementNitrogen
	{
		public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
		#region Costants

		// No property linked to an external XML list in this impact

		#endregion

		#region Constructors

		/// <summary>
		/// Instance default constructor
		/// </summary>
		public NitrogenOne()
		{
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.NITROGEN_FERTILIZATION;
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
					case ("TotalNitrateAmount"):
						_totalNitrateAmount = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("TotalAmmoniaAmount"):
						_totalAmmoniaAmount = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("SurfaceBroadcast"):
						_surfaceBroadcast = bool.Parse(child.Attributes["value"].InnerText);
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
			writer.WriteAttributeString("name","TotalNitrateAmount");
			writer.WriteAttributeString("value", _totalNitrateAmount.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","TotalAmmoniaAmount");
			writer.WriteAttributeString("value", _totalAmmoniaAmount.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","SurfaceBroadcast");
			writer.WriteAttributeString("value", _surfaceBroadcast.ToString());
			writer.WriteEndElement();
		}
		#endregion

		#endregion

        #region IManagementNitrogen members

        private double _totalNitrateAmount;
        /// <summary>
        /// Total amount of nitrogen in form of nitrate applied
        /// </summary>
		public double TotalNitrateAmount
        {
            get { return _totalNitrateAmount; }
            set { _totalNitrateAmount = value; }
        }

        private double _totalAmmoniaAmount;
		/// <summary>
		/// Total amount of nitrogen in form of ammonia applied
		/// </summary>
		public double TotalAmmoniaAmount
        {
            get { return _totalAmmoniaAmount; }
            set { _totalAmmoniaAmount = value; }
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

        //No specific parameter in this impact

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
