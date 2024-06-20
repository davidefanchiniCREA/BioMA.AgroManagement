using System;
using System.Collections.Generic;

using CRA.ModelLayer.Core;
using CRA.AgroManagement;


namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the IrrigationSimple model
    /// </summary>
    public partial class IrrigationSimple
    {

		#region IDomainClass Members

        /// <summary>
        /// Parameters for irrigation
        /// </summary>
		public string Description
		{
			get { return ("Parameters for irrigation"); }
		}

        /// <summary>
        /// Domain class description on the knowledge base
        /// </summary>
		public string URL
		{
			get { return "http://ontology.seamless-ip.org"; }
		}

		#endregion

		#region IVarInfoClass Members

        /// <summary>
        /// Domain class of reference
        /// </summary>
		public string DomainClassOfReference
		{
			get { return "IrrigationSimple"; }
		}

		#endregion

        #region Specific VarInfo properties
        private static VarInfo _irrigationVolumeVarInfo = new VarInfo();
		//VariInfo properties
		/// <summary>
		/// Irrigation volume
		/// </summary>
		public static VarInfo IrrigationVolumeVarInfo
		{
			get { return _irrigationVolumeVarInfo; }
		}
        #endregion

		#region Parameters description
		private void SetParameterDescription()
		{
			_irrigationVolumeVarInfo.Description = "Amount of water applied via irrigation";
			_irrigationVolumeVarInfo.Name = "IrrigationVolume";
			_irrigationVolumeVarInfo.MaxValue = 100;
			_irrigationVolumeVarInfo.MinValue = 0;
			_irrigationVolumeVarInfo.DefaultValue = 35;
			_irrigationVolumeVarInfo.Units = "mm";
			_irrigationVolumeVarInfo.VarType = VarInfo.Type.PARAMETER;
		    _irrigationVolumeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
		}
		#endregion

		#region Test preconditions
		private string VerifyPreconditions( string callID )
		{
			SetParametersInputsCurrentValue();

            /* 29/05/2012 old preconditions API - begin */
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_irrigationVolumeVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class IrrigationSimple"); }



            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
			Preconditions pre = new Preconditions();
			//add range based (current value must be in the range minValue-maxValue)
			prc.AddCondition(new RangeBasedCondition( _irrigationVolumeVarInfo ));
			//get the evaluation of preconditions
			string result = pre.VerifyPreconditions( prc, callID );
			if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class IrrigationSimple" ); }
            /* 29/05/2012 new preconditions API - end */
            
            return result;
		}
		private void SetParametersInputsCurrentValue()
		{
			_irrigationVolumeVarInfo.CurrentValue = _irrigationVolume;
		}
		#endregion

	}
}
