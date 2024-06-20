using System;
using System.Collections.Generic;

using CRA.ModelLayer.Core;
using CRA.AgroManagement;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the ManureSimple model
    /// </summary>
    public partial class ManureSimple
    {
        #region IDomainClass Members

        /// <summary>
        /// Parameters for organic fertilization with a solid fraction via different components
        /// </summary>
        public string Description
        {
            get { return "Parameters for organic fertilization with a solid fraction via different components."; }
        }

        /// <summary>
        /// Domain class description on the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://www.apesimulator.org/ontologybrowser.aspx"; }
        }

        #endregion

        #region IVarInfoClass Members

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "ManureSimple"; }
        }

        #endregion

        #region Specific VarInfo parameters

        private static VarInfo _dryMatterFractionVarInfo = new VarInfo();
        /// <summary>
        /// Dry matter fraction of the organic fertilizer applied
        /// </summary>
        public static VarInfo DryMatterFractionVarInfo
        {
            get { return _dryMatterFractionVarInfo; }
        }

        private static VarInfo _totalAmountVarInfo = new VarInfo();
        /// <summary>
        /// Total amount of organic fertilizer
        /// </summary>
        public static VarInfo TotalAmountVarInfo
        {
            get { return _totalAmountVarInfo; }
        }

        #endregion

        #region Specific parameters
        private static VarInfo _AmmoniaPercentageContentVarInfo = new VarInfo();
        /// <summary>
        /// Percentage content on total amount of manure applied of ammonia
        /// </summary>
        public static VarInfo AmmoniaPercentageContentVarInfo
        {
            get { return _AmmoniaPercentageContentVarInfo; }
        }

        private static VarInfo _NOrganicPercentageContentVarInfo = new VarInfo();
        /// <summary>
        /// Percentage content on total amount of manure applied of organic nitrogen
        /// </summary>
        public static VarInfo NOrganicPercentageContentVarInfo
        {
            get { return _NOrganicPercentageContentVarInfo; }
        }

        private static VarInfo _POnOrganicMatrixPercentageContentVarInfo = new VarInfo();
        /// <summary>
        /// Percentage content on total amount of manure applied of phosporus on organic matrix
        /// </summary>
        public static VarInfo POnOrganicMatrixPercentageContentVarInfo
        {
            get { return _POnOrganicMatrixPercentageContentVarInfo; }
        }

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _totalAmountVarInfo.Description = "Total amount of organic fertilizer supplied";
            _totalAmountVarInfo.Name = "TotalAmount";
            _totalAmountVarInfo.MaxValue = 1000;
            _totalAmountVarInfo.MinValue = 0;
            _totalAmountVarInfo.DefaultValue = 300;
            _totalAmountVarInfo.Units = "Kg/ha";
            _totalAmountVarInfo.VarType = VarInfo.Type.PARAMETER;
            _totalAmountVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _dryMatterFractionVarInfo.Description = "Fraction of dry matter in total amount of organic fertilizer supplied";
            _dryMatterFractionVarInfo.Name = "DryMatterFraction";
            _dryMatterFractionVarInfo.MaxValue = 0.8;
            _dryMatterFractionVarInfo.MinValue = 0.01;
            _dryMatterFractionVarInfo.DefaultValue = 0.25;
            _dryMatterFractionVarInfo.Units = "unitless";
            _dryMatterFractionVarInfo.VarType = VarInfo.Type.PARAMETER;
            _dryMatterFractionVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AmmoniaPercentageContentVarInfo.Description = "Percentage content on total amount of manure applied of ammonia";
            _AmmoniaPercentageContentVarInfo.Name = "AmmoniaPercentageContent";
            _AmmoniaPercentageContentVarInfo.MaxValue = 20;
            _AmmoniaPercentageContentVarInfo.MinValue = 0;
            _AmmoniaPercentageContentVarInfo.DefaultValue = 0;
            _AmmoniaPercentageContentVarInfo.Units = "unitless";
            _AmmoniaPercentageContentVarInfo.VarType = VarInfo.Type.PARAMETER;
            _AmmoniaPercentageContentVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _NOrganicPercentageContentVarInfo.Description = "Percentage content on total amount of manure applied of organic nitrogen";
            _NOrganicPercentageContentVarInfo.Name = "NOrganicPercentageContent";
            _NOrganicPercentageContentVarInfo.MaxValue = 50;
            _NOrganicPercentageContentVarInfo.MinValue = 0;
            _NOrganicPercentageContentVarInfo.DefaultValue = 20;
            _NOrganicPercentageContentVarInfo.Units = "unitless";
            _NOrganicPercentageContentVarInfo.VarType = VarInfo.Type.PARAMETER;
            _NOrganicPercentageContentVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _POnOrganicMatrixPercentageContentVarInfo.Description = "Percentage content on total amount of manure applied of phosporus on organic matrix";
            _POnOrganicMatrixPercentageContentVarInfo.Name = "POnOrganicMatrixPercentageContent";
            _POnOrganicMatrixPercentageContentVarInfo.MaxValue = 20;
            _POnOrganicMatrixPercentageContentVarInfo.MinValue = 0;
            _POnOrganicMatrixPercentageContentVarInfo.DefaultValue = 0;
            _POnOrganicMatrixPercentageContentVarInfo.Units = "unitless";
            _POnOrganicMatrixPercentageContentVarInfo.VarType = VarInfo.Type.PARAMETER;
            _POnOrganicMatrixPercentageContentVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
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
            //prc.RangeBased.Add(_totalAmountVarInfo);
            //prc.RangeBased.Add(_dryMatterFractionVarInfo);
            //prc.RangeBased.Add(_AmmoniaPercentageContentVarInfo);
            //prc.RangeBased.Add(_NOrganicPercentageContentVarInfo);
            //prc.RangeBased.Add(_POnOrganicMatrixPercentageContentVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class ManureSimple"); }

            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_totalAmountVarInfo));
            prc.AddCondition(new RangeBasedCondition(_dryMatterFractionVarInfo));
            prc.AddCondition(new RangeBasedCondition(_AmmoniaPercentageContentVarInfo));
            prc.AddCondition(new RangeBasedCondition(_NOrganicPercentageContentVarInfo));
            prc.AddCondition(new RangeBasedCondition(_POnOrganicMatrixPercentageContentVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class ManureSimple"); }
            /* 29/05/2012 new preconditions API - end */
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _totalAmountVarInfo.CurrentValue = _totalAmount;
            _dryMatterFractionVarInfo.CurrentValue = _dryMatterFraction;
            _AmmoniaPercentageContentVarInfo.CurrentValue = _AmmoniaPercentageContent;
            _NOrganicPercentageContentVarInfo.CurrentValue = _NOrganicPercentageContent;
            _POnOrganicMatrixPercentageContentVarInfo.CurrentValue = _POnOrganicMatrixPercentageContent;
        }
        #endregion
    }
}
