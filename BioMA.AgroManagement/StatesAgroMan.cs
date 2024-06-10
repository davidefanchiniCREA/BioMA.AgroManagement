using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement
{
	/// <summary>
	/// State values used as inputs for testing agromanagement rules at run-time
	/// </summary>
	public class StatesAgroMan : AStatesAgroMan
    {
        #region Constructors

        /// <summary>
		/// Constructor
		/// </summary>
		public StatesAgroMan()
		{
			PhenologicalDates = new PhenologicalDates();
        }

        #endregion

        #region Fields

        VarInfo[] _bulkDensity;
		VarInfo[] _layerThickness;
		VarInfo[] _fieldCapacityVolSWC;
		VarInfo[] _wiltPointVolSWC;
		VarInfo[] _soilWaterContentVol;
		VarInfo[] _soilWaterPotential;

        #endregion

        #region Test pre-conditions

        public ITestsOutput PreconditionsWriter { get; set; }

        /// <summary>
        /// Test of states preconditions
        /// </summary>
        /// <param name="callID">identifier from caller</param>
        /// <returns>list of preconditions violated</returns>
		public virtual string TestPreconditions(string callID)
        {
            //set current value
            SetParametersInputsCurrentValue();

            /* 29/05/2012 old preconditions API - begin */

            ////istance of preconditions data
            //PreconditionsData prc = new PreconditionsData();
            ////instance of preconditions
            //Preconditions pre = new Preconditions();


            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(StatesAgroManVarInfo.AboveGroundBiomass);
            //prc.RangeBased.Add(StatesAgroManVarInfo.AirTemperatureAverage);
            //prc.RangeBased.Add(StatesAgroManVarInfo.LeafAreaIndex);
            //prc.RangeBased.Add(StatesAgroManVarInfo.SugarContent);
            //prc.RangeBased.Add(StatesAgroManVarInfo.WaterLevel);
            //prc.RangeBased.Add(StatesAgroManVarInfo.Rain);
            //prc.RangeBased.Add(StatesAgroManVarInfo.CrownRadius);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateBeginFlowering);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateBeginGrainFilling);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateBeginStemElongation);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateBeginTillering);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateEmergence);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateEndJuvanilePhase);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateEndPhotoInductivePhase);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateFiveLeaves);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateHeading);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateMilkDough);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DatePhysiologicalMaturity);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DatePlanting);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateSoftDough);
            //prc.RangeBased.Add(PhenologicalDatesVarInfo.DateTuberRootInitiation);
            ////Add VarInfo for each soil layer
            //for (int i=0; i<SoilLayers.Count; i++)
            //{
            //    prc.RangeBased.Add(_bulkDensity[i]);
            //    prc.RangeBased.Add(_layerThickness[i]);
            //    prc.RangeBased.Add(_fieldCapacityVolSWC[i]);
            //    prc.RangeBased.Add(_wiltPointVolSWC[i]);
            //    prc.RangeBased.Add(_soilWaterContentVol[i]);
            //    prc.RangeBased.Add(_soilWaterPotential[i]);
            //    prc.GreaterThan.Add(_fieldCapacityVolSWC[i],_wiltPointVolSWC[i]);
            //}
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.dll, class StatesAgroMan"); }
            //return result;

            /* 29/05/2012 old preconditions API - end */
            /* 29/05/2012 new preconditions API - begin  */



            //istance of preconditions data
            ConditionsCollection prc = new ConditionsCollection();
            //instance of preconditions
            Preconditions pre = new Preconditions();


            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.AboveGroundBiomass));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.AirTemperatureAverage));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.LeafAreaIndex));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.SugarContent));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.WaterLevel));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.Rain));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.CrownRadius));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.HostTissueDiseased));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.InfectionEvents));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.GrowingDegreeDays));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.GrowingDegreeDaysTransplanting));
            prc.AddCondition(new RangeBasedCondition(StatesAgroManVarInfo.WaterStress));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateBeginFlowering));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateBeginGrainFilling));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateBeginStemElongation));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateBeginTillering));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateEmergence));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateEndJuvanilePhase));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateEndPhotoInductivePhase));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateFiveLeaves));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateHeading));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateMilkDough));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DatePhysiologicalMaturity));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DatePlanting));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateSoftDough));
            prc.AddCondition(new RangeBasedCondition(PhenologicalDatesVarInfo.DateTuberRootInitiation));
            //Add VarInfo for each soil layer
            for (int i = 0; i < SoilLayers.Count; i++)
            {
                prc.AddCondition(new RangeBasedCondition(_bulkDensity[i]));
                prc.AddCondition(new RangeBasedCondition(_layerThickness[i]));
                prc.AddCondition(new RangeBasedCondition(_fieldCapacityVolSWC[i]));
                prc.AddCondition(new RangeBasedCondition(_wiltPointVolSWC[i]));
                prc.AddCondition(new RangeBasedCondition(_soilWaterContentVol[i]));
                prc.AddCondition(new RangeBasedCondition(_soilWaterPotential[i]));
                prc.AddCondition(new GreaterThanCondition(_fieldCapacityVolSWC[i], _wiltPointVolSWC[i]));
            }
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.dll, class StatesAgroMan"); }
            return result;

            /* 29/05/2012 new preconditions API - end  */

        }

        private void SetParametersInputsCurrentValue()
        {
            //States
            StatesAgroManVarInfo.AboveGroundBiomass.CurrentValue = AboveGroundBiomass;
            StatesAgroManVarInfo.AirTemperatureAverage.CurrentValue = AirTemperatureAverage;
            StatesAgroManVarInfo.LeafAreaIndex.CurrentValue = LeafAreaIndex;
            StatesAgroManVarInfo.SugarContent.CurrentValue = SugarContent;
            StatesAgroManVarInfo.WaterLevel.CurrentValue = WaterLevel;
            StatesAgroManVarInfo.Rain.CurrentValue = Rain;
            StatesAgroManVarInfo.CrownRadius.CurrentValue = CrownRadius;
            StatesAgroManVarInfo.HostTissueDiseased.CurrentValue = HostTissueDiseased;
            StatesAgroManVarInfo.InfectionEvents.CurrentValue = InfectionEvents;
            StatesAgroManVarInfo.GrowingDegreeDays.CurrentValue = GrowingDegreeDays;
            StatesAgroManVarInfo.GrowingDegreeDaysTransplanting.CurrentValue = GrowingDegreeDaysTransplanting;
            StatesAgroManVarInfo.WaterStress.CurrentValue = WaterStress;
			//Phenological dates
			PhenologicalDatesVarInfo.DateBeginFlowering.CurrentValue = PhenologicalDates.DateBeginFlowering;
			PhenologicalDatesVarInfo.DateBeginGrainFilling.CurrentValue = PhenologicalDates.DateBeginGrainFilling;
			PhenologicalDatesVarInfo.DateBeginStemElongation.CurrentValue = PhenologicalDates.DateBeginStemElongation;
			PhenologicalDatesVarInfo.DateBeginTillering.CurrentValue = PhenologicalDates.DateBeginTillering;
			PhenologicalDatesVarInfo.DateEmergence.CurrentValue = PhenologicalDates.DateEmergence;
			PhenologicalDatesVarInfo.DateEndJuvanilePhase.CurrentValue = PhenologicalDates.DateEndJuvanilePhase;
			PhenologicalDatesVarInfo.DateEndPhotoInductivePhase.CurrentValue = PhenologicalDates.DateEndPhotoInductivePhase;
			PhenologicalDatesVarInfo.DateFiveLeaves.CurrentValue = PhenologicalDates.DateFiveLeaves;
			PhenologicalDatesVarInfo.DateHeading.CurrentValue = PhenologicalDates.DateHeading;
			PhenologicalDatesVarInfo.DateMilkDough.CurrentValue = PhenologicalDates.DateMilkDough;
			PhenologicalDatesVarInfo.DatePhysiologicalMaturity.CurrentValue = PhenologicalDates.DatePhysiologicalMaturity;
			PhenologicalDatesVarInfo.DatePlanting.CurrentValue = PhenologicalDates.DatePlanting;
			PhenologicalDatesVarInfo.DateSoftDough.CurrentValue = PhenologicalDates.DateSoftDough;
			PhenologicalDatesVarInfo.DateTuberRootInitiation.CurrentValue = PhenologicalDates.DateTuberRootInitiation;
			//SoilLayers
			int _layers = SoilLayers.Count;
			_bulkDensity = new VarInfo[_layers];
			_layerThickness = new VarInfo[_layers];
			_fieldCapacityVolSWC = new VarInfo[_layers];
			_wiltPointVolSWC = new VarInfo[_layers];
			_soilWaterContentVol = new VarInfo[_layers];
			_soilWaterPotential = new VarInfo[_layers];
			SoilLayer[] sl = new SoilLayer[_layers];
			SoilLayers.CopyTo(0, sl, 0, _layers);
			for (int i = 0; i<_layers; i++)
			{
				_bulkDensity[i] = CRA.AgroManagement.SoilLayerVarInfo.BulkDensity;
				_bulkDensity[i].CurrentValue = sl[i].BulkDensity;
			    _bulkDensity[i].ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				_layerThickness[i] = CRA.AgroManagement.SoilLayerVarInfo.LayerThickness;
				_layerThickness[i].CurrentValue = sl[i].LayerThickness;
                _layerThickness[i].ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				_fieldCapacityVolSWC[i] = CRA.AgroManagement.SoilLayerVarInfo.FieldCapacityVolSWC;
				_fieldCapacityVolSWC[i].CurrentValue = sl[i].FieldCapacityVolSWC;
                _fieldCapacityVolSWC[i].ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				_wiltPointVolSWC[i] = CRA.AgroManagement.SoilLayerVarInfo.WiltPointVolSWC;
				_wiltPointVolSWC[i].CurrentValue = sl[i].WiltPointVolSWC;
                _wiltPointVolSWC[i].ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				_soilWaterContentVol[i] = CRA.AgroManagement.SoilLayerVarInfo.SoilWaterContentVol;
				_soilWaterContentVol[i].CurrentValue = sl[i].SoilWaterContentVol;
                _soilWaterContentVol[i].ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				_soilWaterPotential[i] = CRA.AgroManagement.SoilLayerVarInfo.SoilWaterPotential;
				_soilWaterPotential[i].CurrentValue = sl[i].SoilWaterPotential;
                _soilWaterPotential[i].ValueType = VarInfoValueTypes.GetInstanceForName("Double");
			}
        }
		#endregion

	    #region Overrides of AStatesAgroMan

	    public override IList<string> StrategyUsed
	    {
	        get { return new List<string>(); }
	    }

	    #endregion
        
        public virtual StatesAgroMan CustomClone()
        {
            StatesAgroMan r = new StatesAgroMan();
            r.AboveGroundBiomass = AboveGroundBiomass;
            r.AirTemperatureAverage = AirTemperatureAverage;
            r.CrownRadius = CrownRadius;
            r.DevelopmentStageCode = DevelopmentStageCode;
            r.LeafAreaIndex = LeafAreaIndex;
            r.PhenologicalDates = PhenologicalDates;
            r.PhenologicalState = PhenologicalState;
            r.Rain = Rain;
            r.SoilLayers = SoilLayers;
            r.SoilTemperatureUpperLayer = SoilTemperatureUpperLayer;
            r.SUCROStypeDVS = SUCROStypeDVS;
            r.SugarContent = SugarContent;
            r.WaterLevel = WaterLevel;
            r.GrowingDegreeDays = GrowingDegreeDays;
            r.GrowingDegreeDaysTransplanting = GrowingDegreeDaysTransplanting;
            r.InfectionEvents = InfectionEvents;
            r.WaterStress = WaterStress;

            return r;
        }

    }
}
