using System;
using System.Collections.Generic;
using System.Text;

using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the PesticideICAA model
    /// </summary>
    public partial class PesticidesICAA
    {
        #region IDomainClass members

        /// <summary>
        /// Parameters for agrochemicals spray, several chemicals at once
        /// </summary>
        public string Description
        {
            get { return "Parameters for agrochemicals spray, several chemicals at once"; }
        }

        /// <summary>
        /// Domain class description on the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless-ip.org"; }
        }

        #endregion

        #region IVarInfoClass members

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "PesticidesICAA"; }
        }

        #endregion

        #region Specific VarInfo parameters

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {

        }
        #endregion

        #region Test preconditions

        /// <summary>
        /// test of pre-conditions
        /// </summary>
        /// <param name="callID">identifier from caller</param>
        /// <returns>pre-conditions violated</returns>
        public string TestPreconditions(string callID)
        {
            return VerifyPreconditions(callID);
        }

        private string VerifyPreconditions(string callID)
        {
            SetParametersInputsCurrentValue();
            string result = String.Empty;
            PreconditionsData prc = new PreconditionsData();
            Preconditions pre = new Preconditions();
            foreach (Pesticide p in _agroChemicals)
            {
                result += p.VerifyPreconditions(callID);
            }
            //get the evaluation of preconditions
            //result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class PesticidesICAA"); }
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {

        }
        #endregion

        /// <summary>
        /// VarInfo of parameters in the types used in the PesticideICAA class 
        /// </summary>
        public partial class Pesticide
        {
            #region Specific VarInfo parameters

            private static VarInfo _pesticideAmountVarInfo = new VarInfo();
            /// <summary>
            /// Pesticide amount applied
            /// </summary>
            public static VarInfo PesticideAmountVarInfo
            {
                get { return _pesticideAmountVarInfo; }
            }

            private static VarInfo _fractionChemicalVarInfo = new VarInfo();
            /// <summary>
            /// Fraction of active chemical in pesticide applied
            /// </summary>
            public static VarInfo FractionChemicalVarInfo
            {
                get { return _fractionChemicalVarInfo; }
            }

            #endregion

            #region Parameters description

            private void SetParameterDescription()
            {
                _pesticideAmountVarInfo.Description = "Amount of pesticide applied";
                _pesticideAmountVarInfo.Name = "PesticideAmount";
                _pesticideAmountVarInfo.MaxValue = 100;
                _pesticideAmountVarInfo.MinValue = 0;
                _pesticideAmountVarInfo.DefaultValue = 1;
                _pesticideAmountVarInfo.Units = "kg ha-1";
                _pesticideAmountVarInfo.VarType = VarInfo.Type.PARAMETER;
                _pesticideAmountVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                _fractionChemicalVarInfo.Description = "Fraction of chemical in amount applied";
                _fractionChemicalVarInfo.Name = "FractionChemical";
                _fractionChemicalVarInfo.MaxValue = 1;
                _fractionChemicalVarInfo.MinValue = 0;
                _fractionChemicalVarInfo.DefaultValue = 0.25;
                _fractionChemicalVarInfo.Units = "unitless";
                _fractionChemicalVarInfo.VarType = VarInfo.Type.PARAMETER;
                _fractionChemicalVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            }
            #endregion

            #region Test preconditions
            internal string VerifyPreconditions(string callID)
            {
                SetParametersInputsCurrentValue();

                /* 29/05/2012 old preconditions API - begin */
                //PreconditionsData prc = new PreconditionsData();
                //Preconditions pre = new Preconditions();
                ////add range based (current value must be in the range minValue-maxValue)
                //prc.RangeBased.Add(_pesticideAmountVarInfo);
                //prc.RangeBased.Add(_fractionChemicalVarInfo);
                ////get the evaluation of preconditions
                //string result = pre.VerifyPreconditions(prc, callID);

                /* 29/05/2012 old preconditions API - end */

                /* 29/05/2012 new preconditions API - begin */
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions();
                //add range based (current value must be in the range minValue-maxValue)
                prc.AddCondition(new RangeBasedCondition(_pesticideAmountVarInfo));
                prc.AddCondition(new RangeBasedCondition(_fractionChemicalVarInfo));
                //get the evaluation of preconditions
                string result = pre.VerifyPreconditions(prc, callID);
                /* 29/05/2012 new preconditions API - end */
                
                return result;
            }
            private void SetParametersInputsCurrentValue()
            {
                _pesticideAmountVarInfo.CurrentValue = _pesticideAmount;
                _fractionChemicalVarInfo.CurrentValue = _fractionChemical;
            }
            #endregion
        }

    }
}