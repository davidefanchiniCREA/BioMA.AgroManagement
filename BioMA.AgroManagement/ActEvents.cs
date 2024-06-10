using System;
using System.Collections.Generic;
//using CRA.AgroManagement.impacts;

using System.Xml;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Actual events contains the impact objects relevant
	/// to the rules met at a given time step.
	/// </summary>
    public class ActEvents : ManagementCollection<IManagement>
    {
        public ActEvents()
        {

        }


        public ActEvents(ManagementCollection<IManagement> mc)
        {
            base.ProductionActivity = mc.ProductionActivity;
            _management = mc.Management;
        }

	    private List<IManagement> _management = new List<IManagement>();
        //private string _productionActivity;

        ///// <summary>
        ///// Production activity
        ///// </summary>
        //public override string ProductionActivity
        //{
        //    get	{ return productionActivity; }
        //    set { productionActivity = value; }
        //}

        /// <summary>
        /// Impact objects published if rules are satisfied
        /// 
        /// </summary>
		public override List<IManagement> Management
        {
            get
            {
                return _management;
            }
            set
            {
                _management = value;
            }
        }
         
    }
}
