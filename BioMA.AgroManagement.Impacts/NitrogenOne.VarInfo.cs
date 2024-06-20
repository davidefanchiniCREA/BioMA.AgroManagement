using System;
using System.Collections.Generic;
using System.Text;

using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the NitrogenOne model
    /// </summary>
    public partial class NitrogenOne
    {

        #region IDomainClass Members
        /// <summary>
        /// Parameters for mineral nitrogen fertilization using ammonia and nitrate fractions
        /// </summary>
        public string Description
        {
            get { return "Parameters for mineral nitrogen fertilization using ammonia and nitrate fractions"; }
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
            get { return "CRA.AgroManagement.Impacts.NitrogenOne"; }
        }

        #endregion

        #region Specific VarInfo parameters
 
        private static VarInfo _totalNitrateAmountVarInfo = new VarInfo();
        /// <summary>
        /// Total amount of nitrogen in form of nitrate applied
        /// </summary>
        public static VarInfo TotalNitrateAmountVarInfo
        {
            get { return _totalNitrateAmountVarInfo; }
        }

        private static VarInfo _totalAmmoniaAmountVarInfo = new VarInfo();
        /// <summary>
        /// Total amount of nitrogen in form of ammonia applied
        /// </summary>
        public static VarInfo TotalAmmoniaAmountVarInfo
        {
            get { return _totalAmmoniaAmountVarInfo; }
        }

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _totalNitrateAmountVarInfo.Description = "Total amount of N supplied in the form of nitrate";
            _totalNitrateAmountVarInfo.Name = "TotalNitrateAmount";
            _totalNitrateAmountVarInfo.MaxValue = 300;
            _totalNitrateAmountVarInfo.MinValue = 0;
            _totalNitrateAmountVarInfo.DefaultValue = 50;
            _totalNitrateAmountVarInfo.Units = "Kg/ha";
            _totalNitrateAmountVarInfo.VarType = VarInfo.Type.PARAMETER;
            _totalNitrateAmountVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _totalAmmoniaAmountVarInfo.Description = "Total amount of N supplied in the form of ammonia";
            _totalAmmoniaAmountVarInfo.Name = "TotalNitrateAmount";
            _totalAmmoniaAmountVarInfo.MaxValue = 300;
            _totalAmmoniaAmountVarInfo.MinValue = 0;
            _totalAmmoniaAmountVarInfo.DefaultValue = 50;
            _totalAmmoniaAmountVarInfo.Units = "Kg/ha";
            _totalAmmoniaAmountVarInfo.VarType = VarInfo.Type.PARAMETER;
            _totalAmmoniaAmountVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
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
            //prc.RangeBased.Add(_totalAmmoniaAmountVarInfo);
            //prc.RangeBased.Add(_totalNitrateAmountVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.dll, class NitrogenOne"); }

            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_totalAmmoniaAmountVarInfo));
            prc.AddCondition(new RangeBasedCondition(_totalNitrateAmountVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.dll, class NitrogenOne"); }
            /* 29/05/2012 new preconditions API - end */

            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _totalAmmoniaAmountVarInfo.CurrentValue = _totalAmmoniaAmount;
            _totalNitrateAmountVarInfo.CurrentValue = _totalNitrateAmount;
        }
        #endregion

    }
}
