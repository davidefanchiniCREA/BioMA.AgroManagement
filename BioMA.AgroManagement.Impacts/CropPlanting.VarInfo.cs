using System;
using System.Collections.Generic;
using System.Text;

using CRA.ModelLayer.Core;
using CRA.AgroManagement;
using System.ComponentModel;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// Parameters for crop planting
    /// </summary>
    public partial class CropPlanting
    {
        
        #region IDomainClass Members

        /// <summary>
        /// Parameters for crop planting
        /// </summary>
      
        public string Description
        {
            get { return ("Parameters for crop planting"); }
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
            get { return "CRA.AgroManagement.Impacts.CropPlanting"; }
        }

        #endregion

        #region Specific VarInfo parameters

        private static VarInfo _plantingDepthVarInfo = new VarInfo();
        /// <summary>
        /// Planting depth
        /// </summary>
        public static VarInfo PlantingDepthVarInfo
        {
            get { return _plantingDepthVarInfo; }
        }

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _plantingDepthVarInfo.Description = "Mean planting depth";
            _plantingDepthVarInfo.Name = "PlantingDepth";
            _plantingDepthVarInfo.MaxValue = 0.15;
            _plantingDepthVarInfo.MinValue = 0.01;
            _plantingDepthVarInfo.DefaultValue = 0.03;
            _plantingDepthVarInfo.Units = "m";
            _plantingDepthVarInfo.VarType = VarInfo.Type.PARAMETER;
            _plantingDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }
        #endregion

        #region Test preconditions
        private string VerifyPreconditions(string callID)
        {
            SetParametersInputsCurrentValue();

            /* 29/05/2012 old preconditions API - begin */
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_plantingDepthVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class CropPlanting"); }


            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_plantingDepthVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class CropPlanting"); }
            /* 29/05/2012 new preconditions API - end */
            
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _plantingDepthVarInfo.CurrentValue = _plantingDepth;
        }
        #endregion

    }
}
