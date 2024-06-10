using System;
using System.Collections.Generic;
using System.Reflection;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Data-type with phenological dates
	/// </summary>
	public class PhenologicalDates : IDomainClass

	{
        
	    #region IDomainClass Members

        /// <summary>
        /// Dates of phenological events
        /// </summary>
        public string Description
        {
            get { return "Dates of phenological events"; }
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

		#region Private fields to hold property values
 
        private int _datePlanting;
        private int _dateEmergence;
        private int _dateFiveLeaves;
        private int _dateEndJuvanilePhase;
        private int _dateHeading;
        private int _dateBeginTillering;
        private int _dateTuberRootInitiation;
        private int _dateEndPhotoInductivePhase;
        private int _dateBeginStemElongation;
        private int _dateBeginFlowering;
        private int _dateBeginGrainFilling;
        private int _dateMilkDough;
        private int _dateSoftDough;
        private int _datePhysiologicalMaturity;
        //New ones July 16 2008
	    private int _dateTenTwelveLeaves;
	    private int _dateEarOneCm;
	    private int _dateLastLeaf;
	    private int _dateBeginLeafSenescence;
	    private int _dateHarvest;
	    private int _dateLastCut;
		
        #endregion

		#region Properties

        /// <summary>
        /// Last cut of forage 
        /// </summary>
        public int DateLastCut
        {
            get { return _dateLastCut; }
            set { _dateLastCut = value; }
        }

        /// <summary>
        /// Harvest 
        /// </summary>
        public int DateHarvest
        {
            get { return _dateHarvest; }
            set { _dateHarvest = value; }
        }

        /// <summary>
        /// Beging of canopy senescence 
        /// </summary>
        public int DateBeginLeafSenescence
        {
            get { return _dateBeginLeafSenescence; }
            set { _dateBeginLeafSenescence = value; }
        }

        /// <summary>
        /// Last leaf expanded 
        /// </summary>
        public int DateLastLeaf
        {
            get { return _dateLastLeaf; }
            set { _dateLastLeaf = value; }
        }

        /// <summary>
        /// Ear one centimeter length 
        /// </summary>
        public int DateEarOneCm
        {
            get { return _dateEarOneCm; }
            set { _dateEarOneCm = value; }
        }

        /// <summary>
        /// Ten-twelve leaves 
        /// </summary>
        public int DateTenTwelveLeaves
        {
            get { return _dateTenTwelveLeaves; }
            set { _dateTenTwelveLeaves  = value; }
        }

		/// <summary>
		/// Physiological maturity
		/// </summary>
		public int DatePhysiologicalMaturity
		{
			get { return _datePhysiologicalMaturity; }
			set { _datePhysiologicalMaturity = value; }
		}
			
		/// <summary>
		/// Grain soft dough
		/// </summary>
		public int DateSoftDough
		{
			get { return _dateSoftDough; }
			set { _dateSoftDough = value; }
		}
			
		/// <summary>
		/// Grain milk dough
		/// </summary>
		public int DateMilkDough
		{
			get { return _dateMilkDough; }
			set { _dateMilkDough = value; }
		}
			
		/// <summary>
		/// Begin grain filling
		/// </summary>
		public int DateBeginGrainFilling
		{
			get { return _dateBeginGrainFilling; }
			set { _dateBeginGrainFilling = value; }
		}
			
		/// <summary>
		/// Begin flowering
		/// </summary>
		public int DateBeginFlowering
		{
			get { return _dateBeginFlowering; }
			set { _dateBeginFlowering = value; }
		}
			
		/// <summary>
		/// Begin stem elongation
		/// </summary>
		public int DateBeginStemElongation
		{
			get { return _dateBeginStemElongation; }
			set { _dateBeginStemElongation = value; }
		}

		/// <summary>
		/// Begin heading
		/// </summary>
		public int DateHeading
		{
			get { return _dateHeading; }
			set { _dateHeading = value; }
		}
			
		/// <summary>
		/// End photo inductive phase
		/// </summary>
		public int DateEndPhotoInductivePhase
		{
			get { return _dateEndPhotoInductivePhase; }
			set { _dateEndPhotoInductivePhase = value; }
		}
			
		/// <summary>
		/// Tuber root initiation
		/// </summary>
		public int DateTuberRootInitiation
		{
			get { return _dateTuberRootInitiation; }
			set { _dateTuberRootInitiation = value; }
		}
			
		/// <summary>
		/// Begin tillering
		/// </summary>
		public int DateBeginTillering
		{
			get { return _dateBeginTillering; }
			set { _dateBeginTillering = value; }
		}

		/// <summary>
		/// End juvanile phase
		/// </summary>
		public int DateEndJuvanilePhase
		{
			get { return _dateEndJuvanilePhase; }
			set { _dateEndJuvanilePhase = value; }
		}
			
		/// <summary>
		/// five leaves formed
		/// </summary>
		public int DateFiveLeaves
		{
			get { return _dateFiveLeaves; }
			set { _dateFiveLeaves = value; }
		}
			
		/// <summary>
		/// date emergence
		/// </summary>
		public int DateEmergence
		{
			get { return _dateEmergence; }
			set { _dateEmergence = value; }
		}

		/// <summary>
		/// date planting
		/// </summary>
		public int DatePlanting
		{
			get { return _datePlanting; }
			set { _datePlanting = value; }
		}
		#endregion 

        public PhenologicalDates()
        {
            _io = new ParametersIO(this);
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
	          _datePlanting=0;
        _dateEmergence=0;
        _dateFiveLeaves=0;
        _dateEndJuvanilePhase=0;
        _dateHeading=0;
        _dateBeginTillering=0;
        _dateTuberRootInitiation=0;
        _dateEndPhotoInductivePhase=0;
        _dateBeginStemElongation=0;
        _dateBeginFlowering=0;
        _dateBeginGrainFilling=0;
        _dateMilkDough=0;
        _dateSoftDough=0;
        _datePhysiologicalMaturity=0;        
	    _dateTenTwelveLeaves=0;
	    _dateEarOneCm=0;
	    _dateLastLeaf=0;
	    _dateBeginLeafSenescence=0;
	    _dateHarvest=0;
	    _dateLastCut=0;
	        return true;
	    }

	    #endregion
    }
}
