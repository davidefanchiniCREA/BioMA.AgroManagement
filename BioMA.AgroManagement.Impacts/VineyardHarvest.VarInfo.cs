using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the VineyardHarvest model
    /// </summary>
    public partial class VineyardHarvest
    {
        #region IDomainClass Members

        /// <summary>
        /// Parameters for vineyard harvest
        /// </summary>
        public string Description
        {
            get { return ("Parameters for vineyard harvest"); }
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
            get { return "CRA.AgroManagement.Impacts.VineyardHarvest"; }
        }

        #endregion

        #region Specific VarInfo parameters

        private static VarInfo _yieldLossFractionVarInfo = new VarInfo();
        /// <summary>
        /// Fraction of yiled loss during harvest
        /// </summary>
        public static VarInfo YieldLossFractionVarInfo
        {
            get { return _yieldLossFractionVarInfo; }
        }

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _yieldLossFractionVarInfo.Name = "YieldLoss";
            _yieldLossFractionVarInfo.Description = "Fraction of yield loss at harvest";
            _yieldLossFractionVarInfo.MaxValue = 0.3;
            _yieldLossFractionVarInfo.MinValue = 0;
            _yieldLossFractionVarInfo.DefaultValue = 0.05;
            _yieldLossFractionVarInfo.Units = "unitless";
            _yieldLossFractionVarInfo.URL = "http://www.seamless-if.org/ontology";
            _yieldLossFractionVarInfo.VarType = VarInfo.Type.PARAMETER;
            _yieldLossFractionVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        #endregion

        #region Test preconditions
        private string VerifyPreconditions(string callID)
        {
            string result = String.Empty;
            /* 29/05/2012 old preconditions API - begin */
            
            //#LE#:2015-09-19: scommento la chiamata perchè se no non si imposta il valore corrente
            SetParametersInputsCurrentValue();
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_yieldLossFractionVarInfo);
            ////get the evaluation of preconditions
            //result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class VineyardHarvest"); }


            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_yieldLossFractionVarInfo));
            //get the evaluation of preconditions
            result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class VineyardHarvest"); }
            /* 29/05/2012 new preconditions API - end */
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _yieldLossFractionVarInfo.CurrentValue = _yieldLossFraction;
        }
        #endregion
    }
}
