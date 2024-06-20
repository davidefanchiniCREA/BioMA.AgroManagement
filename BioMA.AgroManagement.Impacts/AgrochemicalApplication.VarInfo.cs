using System;
using System.Collections.Generic;
using System.Text;

using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the PesticideICAA model
    /// </summary>
    public partial class AgrochemicalApplication
    {
        #region IDomainClass members

        /// <summary>
        /// Parameters for agrochemicals spray
        /// </summary>
        public string Description
        {
            get { return "Parameters for agrochemicals spray"; }
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
            get { return "AgrochemicalApplication"; }
        }

        #endregion


        #region Specific VarInfo parameters

        private static VarInfo _agrochemicalDosePercentageVarInfo = new VarInfo();
        /// <summary>
        ///Agrochemical dose percentage
        /// </summary>
        public static VarInfo AgrochemicalDosePercentageVarInfo
        {
            get { return _agrochemicalDosePercentageVarInfo; }
        }

        private static VarInfo _degradationRateVarInfo = new VarInfo();
        /// <summary>
        ///Agrochemical dose percentage
        /// </summary>
        public static VarInfo DegradationRateVarInfo
        {
            get { return _degradationRateVarInfo; }
        }


        private static VarInfo _tenacityFactorVarInfo = new VarInfo();
        /// <summary>
        ///Agrochemical dose percentage
        /// </summary>
        public static VarInfo TenacityFactorVarInfo
        {
            get { return _tenacityFactorVarInfo; }
        }


        private static VarInfo _agrochemicalEfficacyVarInfo = new VarInfo();
        /// <summary>
        ///Agrochemical dose percentage
        /// </summary>
        public static VarInfo AgrochemicalEfficacyVarInfo
        {
            get { return _agrochemicalEfficacyVarInfo; }
        }


        private static VarInfo _aShapeParameterVarInfo = new VarInfo();
        /// <summary>
        ///Agrochemical dose percentage
        /// </summary>
        public static VarInfo AShapeParameterVarInfo
        {
            get { return _aShapeParameterVarInfo; }
        }


        private static VarInfo _bShapeParameterVarInfo = new VarInfo();
        /// <summary>
        ///Agrochemical dose percentage
        /// </summary>
        public static VarInfo BShapeParameterVarInfo
        {
            get { return _bShapeParameterVarInfo; }
        }



        #endregion

        #region Parameters description

        private void SetParameterDescription()
        {
            _agrochemicalDosePercentageVarInfo.Description = "Percentage dose of agrochemical";
            _agrochemicalDosePercentageVarInfo.Name = "AgrochemicalDosePercentage";
            _agrochemicalDosePercentageVarInfo.MaxValue = 1;
            _agrochemicalDosePercentageVarInfo.MinValue = 0;
            _agrochemicalDosePercentageVarInfo.DefaultValue = 1;
            _agrochemicalDosePercentageVarInfo.Units = "%";
            _agrochemicalDosePercentageVarInfo.VarType = VarInfo.Type.PARAMETER;
            _agrochemicalDosePercentageVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _degradationRateVarInfo.Description = "Degradation rate constant";
            _degradationRateVarInfo.Name = "DegradationRate";
            _degradationRateVarInfo.MaxValue = 0.2;
            _degradationRateVarInfo.MinValue = 0.01;
            _degradationRateVarInfo.DefaultValue = .1;
            _degradationRateVarInfo.Units = "unitless";
            _degradationRateVarInfo.VarType = VarInfo.Type.PARAMETER;
            _degradationRateVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _tenacityFactorVarInfo.Description = "Tenacity factor for wash-off due to rain";
            _tenacityFactorVarInfo.Name = "TenacityFactor";
            _tenacityFactorVarInfo.MaxValue = 0.3;
            _tenacityFactorVarInfo.MinValue = 0;
            _tenacityFactorVarInfo.DefaultValue = .2;
            _tenacityFactorVarInfo.Units = "unitless";
            _tenacityFactorVarInfo.VarType = VarInfo.Type.PARAMETER;
            _tenacityFactorVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _agrochemicalEfficacyVarInfo.Description = "Agrochemical efficacy at application";
            _agrochemicalEfficacyVarInfo.Name = "AgrochemicalEfficacy";
            _agrochemicalEfficacyVarInfo.MaxValue = 1;
            _agrochemicalEfficacyVarInfo.MinValue = 0.5;
            _agrochemicalEfficacyVarInfo.DefaultValue = .85;
            _agrochemicalEfficacyVarInfo.Units = "unitless";
            _agrochemicalEfficacyVarInfo.VarType = VarInfo.Type.PARAMETER;
            _agrochemicalEfficacyVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _aShapeParameterVarInfo.Description = "a shape parameter of fungicide efficacy";
            _aShapeParameterVarInfo.Name = "AShapeParameter";
            _aShapeParameterVarInfo.MaxValue = 4.5;
            _aShapeParameterVarInfo.MinValue = 3.5;
            _aShapeParameterVarInfo.DefaultValue = 4;
            _aShapeParameterVarInfo.Units = "unitless";
            _aShapeParameterVarInfo.VarType = VarInfo.Type.PARAMETER;
            _aShapeParameterVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _bShapeParameterVarInfo.Description = "b shape parameter of fungicide efficacy";
            _bShapeParameterVarInfo.Name = "BShapeParameter";
            _bShapeParameterVarInfo.MaxValue = 9;
            _bShapeParameterVarInfo.MinValue = 8;
            _bShapeParameterVarInfo.DefaultValue = 8.5;
            _bShapeParameterVarInfo.Units = "unitless";
            _bShapeParameterVarInfo.VarType = VarInfo.Type.PARAMETER;
            _bShapeParameterVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");


        }
        #endregion

        #region Test preconditions
        public string TestPreconditions(string callID)
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
            prc.AddCondition(new RangeBasedCondition(_agrochemicalDosePercentageVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            /* 29/05/2012 new preconditions API - end */

            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _agrochemicalDosePercentageVarInfo.CurrentValue = _agrochemicalDosePercentage;
            _agrochemicalEfficacyVarInfo.CurrentValue = _agrochemicalEfficacy;
            _aShapeParameterVarInfo.CurrentValue = _aShapeParameterVarInfo;
            _bShapeParameterVarInfo.CurrentValue = _bShapeParameter;
            _degradationRateVarInfo.CurrentValue = _degradationRate;
            _tenacityFactorVarInfo.CurrentValue = _tenacityFactor;
            
        }
        #endregion

    }
}