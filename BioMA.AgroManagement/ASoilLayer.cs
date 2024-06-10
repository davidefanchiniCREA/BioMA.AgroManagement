using System;
using System.Collections.Generic;
using System.Reflection;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Soil layer properties 
	/// </summary>
	public abstract class ASoilLayer : IDomainClass 		
	{

        private double _bulkDensity;
        private double _layerThickness;
        private double _fieldCapacityVolSWC;
        private double _wiltPointVolSWC;
        private double _soilWaterContentVol;
        private double _soilWaterPotential;
 
	    #region IDomainClass Members

        /// <summary>
        /// Soil layers base class
        /// </summary>
        public string Description
        {
            get { return "Soil layers base class"; }
        }

        /// <summary>
        /// Description of the domain class on the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless-ip.org"; }
        }

	    public IList<string> StrategyUsed
	    {
	        get { return new List<string>(); }
	    }

	    #endregion

		#region SoilLayer properties
		/// <summary>
		/// bulkDensity
		/// </summary>
		public virtual double BulkDensity
		{
			get { return _bulkDensity; }
			set { _bulkDensity = value;  }
		}
		/// <summary>
		/// layerThickness
		/// </summary>
		public virtual double LayerThickness
		{
			get { return _layerThickness; }
			set { _layerThickness = value; }
		}
		/// <summary>
		/// fieldCapacityVolSWC
		/// </summary>
		public virtual double FieldCapacityVolSWC
		{
			get { return _fieldCapacityVolSWC; }
			set { _fieldCapacityVolSWC=value; }
		}
		/// <summary>
		/// wiltPointVolSWC
		/// </summary>
		public virtual double WiltPointVolSWC
		{
			get { return _wiltPointVolSWC; }
			set { _wiltPointVolSWC=value; }
		}
		/// <summary>
		/// soilWaterContentVol
		/// </summary>
		public virtual double SoilWaterContentVol
		{
			get { return _soilWaterContentVol; }
			set { _soilWaterContentVol=value; }
		}	
		/// <summary>
		/// soilWaterPotential
		/// </summary>
		public virtual double SoilWaterPotential
		{
			get { return _soilWaterPotential; }
			set { _soilWaterPotential = value; }
		}		
		#endregion


        public ASoilLayer()
        {
            _io = new ParametersIO(this);
        }

	    #region Implementation of IDomainClass

	    private readonly ParametersIO _io;
	    public IDictionary<string, PropertyInfo> PropertiesDescription
	    {
	        get {

                return _io.GetCachedProperties();
            }
	    }

	    public bool ClearValues()
	    {
	          _bulkDensity=0;
        _layerThickness=0;
        _fieldCapacityVolSWC=0;
        _wiltPointVolSWC=0;
        _soilWaterContentVol=0;
        _soilWaterPotential=0;
	        return true;
	    }

	    #endregion

    }
}