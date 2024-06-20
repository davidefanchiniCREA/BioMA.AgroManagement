using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using CRA.AgroManagement;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the TillageWepp model
    /// </summary>
    public partial class TillageWepp
    {
        #region IDomainClass Members

        /// <summary>
        /// Parameters to implement tillage via implements in a list according to the Wepp approach
        /// </summary>
        public string Description
        {
            get { return "Parameters to implement tillage via implements in a list according to the Wepp approach"; }
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
            get { return "CRA.AgroManagement.Impacts.TillageWepp"; }
        }

        #endregion

        #region Specific VarInfo parameters
        private static VarInfo _meanTillageDepthVarInfo = new VarInfo();
        /// <summary>
        /// Mean depth from surface of tillage event
        /// </summary>
        public static VarInfo MeanTillageDepthVarInfo
        {
            get { return _meanTillageDepthVarInfo; }
        }
        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _meanTillageDepthVarInfo.Description = "Mean depth of tillage";
            _meanTillageDepthVarInfo.Name = "MeanTillageDepth";
            _meanTillageDepthVarInfo.MaxValue = 1;
            _meanTillageDepthVarInfo.MinValue = 0.1;
            _meanTillageDepthVarInfo.DefaultValue = 0.15;
            _meanTillageDepthVarInfo.Units = "m";
            _meanTillageDepthVarInfo.VarType = VarInfo.Type.PARAMETER;
            _meanTillageDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }
        #endregion

        #region Test preconditions

		/// <summary>
		/// test of pre-conditions
		/// </summary>
		/// <param name="callID">identifier from caller</param>
		/// <returns>pre-conditions violated</returns>
		public string TestPreconditions( string callID )
		{
			return VerifyPreconditions( callID );
		}

        private string VerifyPreconditions(string callID)
        {
            SetParametersInputsCurrentValue();

            /* 29/05/2012 old preconditions API - begin */
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_meanTillageDepthVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class TillageWepp"); }

            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_meanTillageDepthVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class TillageWepp"); }
            /* 29/05/2012 new preconditions API - end */
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _meanTillageDepthVarInfo.CurrentValue = _meanTillageDepth;
        }
        #endregion

        public IList<string> StrategyUsed
        {
            get { return new List<string>(); }
        }



        #region Implementation of IDomainClass

        private readonly ParametersIO _io;
        public IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {

                return _io.GetCachedProperties(typeof(IDomainClass));
            }
        }

        public bool ClearValues()
        {
            return true;
        }

        #endregion

    }
}
