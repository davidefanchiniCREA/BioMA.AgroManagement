using System;
using System.Collections.Generic;
using System.Text;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// VarInfo data and methods of the TreeStart model
    /// </summary>
    public partial class TreeStart
    {
        #region IDomainClass Members

        /// <summary>
        /// Parameters for tree/vineyard/orchard start
        /// </summary>
        public string Description
        {
            get { return ("Parameters for tree/vineyard/orchard start"); }
        }

        /// <summary>
        /// Domain class desctription in the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless-ip.org"; }
        }

        #endregion

        #region IVarInfoClass Members

        /// <summary>Domain class of reference</summary>
        public string DomainClassOfReference
        {
            get { return "CRA.AgroManagement.Impacts.TreeStart"; }
        }

        #endregion

        #region Specific VarInfo parameters

        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            // No specific parameter in this class
        }

        #endregion

        #region Test preconditions
        private string VerifyPreconditions(string callID)
        {
            string result = String.Empty;
            SetParametersInputsCurrentValue();
            
            
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            
            ////get the evaluation of preconditions
            //result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class TreeStart"); }
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            // No specific parameter in this class
        }
        #endregion
    }
}
