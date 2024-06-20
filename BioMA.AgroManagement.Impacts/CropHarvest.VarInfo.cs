using System;
using System.Collections.Generic;
using System.Text;

using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// Parameters for crop harvest
    /// </summary>
    public partial class CropHarvest
    {
        #region IDomainClass Members

        /// <summary>
        /// Parameters for crop harvest
        /// </summary>
        public string Description
        {
            get { return ("Parameters for crop harvest"); }
        }

        /// <summary>
        /// Domain class on the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless.org"; }
        }

        #endregion

        #region IVarInfoClass Members

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "CRA.AgroManagement.Impacts.CropHarvest"; }
        }

        #endregion

        #region Specific VarInfo parameters
        private static VarInfo _yieldLossFractionVarInfo = new VarInfo();
        /// <summary>
        /// Yield loss at harvest
        /// </summary>
        public static VarInfo YieldLossFractionVarInfo
        {
            get { return _yieldLossFractionVarInfo; }
        }

        private static VarInfo _residualRemovalFractionVarInfo = new VarInfo();
        /// <summary>
        /// Residual remuval at harvest
        /// </summary>
        public static VarInfo ResidualRemovalFractionVarInfo
        {
            get { return _residualRemovalFractionVarInfo; }
        }
        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _yieldLossFractionVarInfo.Description = "Fraction of yield loss at harvest";
            _yieldLossFractionVarInfo.Name = "YieldLossFraction";
            _yieldLossFractionVarInfo.MaxValue = 0.25;
            _yieldLossFractionVarInfo.MinValue = 0;
            _yieldLossFractionVarInfo.DefaultValue = 0.07;
            _yieldLossFractionVarInfo.Units = "unitless";
            _yieldLossFractionVarInfo.VarType = VarInfo.Type.PARAMETER;
            _yieldLossFractionVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _residualRemovalFractionVarInfo.Description = "Fraction of the residuals removed from field";
            _residualRemovalFractionVarInfo.Name = "ResidualRemovalFraction";
            _residualRemovalFractionVarInfo.MaxValue = 100;
            _residualRemovalFractionVarInfo.MinValue = 0;
            _residualRemovalFractionVarInfo.DefaultValue = 0;
            _residualRemovalFractionVarInfo.Units = "unitless";
            _residualRemovalFractionVarInfo.VarType = VarInfo.Type.PARAMETER;
            _residualRemovalFractionVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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
            //prc.RangeBased.Add(_yieldLossFractionVarInfo);
            //prc.RangeBased.Add(_residualRemovalFractionVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class CropHarvest"); }


            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_yieldLossFractionVarInfo));
            prc.AddCondition(new RangeBasedCondition(_residualRemovalFractionVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class CropHarvest"); }
            /* 29/05/2012 new preconditions API - end */
            
            
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _yieldLossFractionVarInfo.CurrentValue = _yieldLossFraction;
            _residualRemovalFractionVarInfo.CurrentValue = _residualRemovalFraction;
        }
        #endregion
    }
}
