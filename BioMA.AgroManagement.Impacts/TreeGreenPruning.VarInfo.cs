using System;
using System.Collections.Generic;
using System.Text;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the TreeGreenPruning model
    /// </summary>
    public partial class TreeGreenPruning
    {
        #region IDomainClass Members

        /// <summary>
        /// Parameters for tree green pruning
        /// </summary>
        public string Description
        {
            get { return ("Parameters for tree green pruning"); }
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
            get { return "CRA.AgroManagement.Impacts.TreePruning"; }
        }

        #endregion

        #region Specific VarInfo parameters

        private static VarInfo _residualLAIVarInfo = new VarInfo();
        /// <summary>
        /// Residual LAI after green pruning
        /// </summary>
        public static VarInfo ResidualLAIVarInfo
        {
            get { return _residualLAIVarInfo; }
        }        

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _residualLAIVarInfo.Name = "ResidualLAI";
            _residualLAIVarInfo.Description = "LAI residual after pruning";
            _residualLAIVarInfo.MaxValue = 10;
            _residualLAIVarInfo.MinValue = 1;
            _residualLAIVarInfo.DefaultValue = 2.5;
            _residualLAIVarInfo.Units = "unitless";
            _residualLAIVarInfo.URL = "http://www.seamless-if.org/ontology";
            _residualLAIVarInfo.VarType = VarInfo.Type.PARAMETER;
            _residualLAIVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        #endregion

        #region Test preconditions
        private string VerifyPreconditions(string callID)
        {
            string result = String.Empty;
            SetParametersInputsCurrentValue();
            /* 29/05/2012 old preconditions API - begin */
            
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_residualLAIVarInfo);
            ////get the evaluation of preconditions
            //result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class TreeGreenPruning"); }
            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_residualLAIVarInfo));
            //get the evaluation of preconditions
            result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class TreeGreenPruning"); }
            /* 29/05/2012 new preconditions API - end */

            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _residualLAIVarInfo.CurrentValue = _residualLAI;
        }
        #endregion
    }
}
