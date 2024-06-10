using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Data-type containing scheduled rules and events
	/// </summary>
	public class SchEvents
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public SchEvents()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		private string _productionActivity;
		private List<IRules> _rules = new List<IRules>();
        private List<IManagement> _management = new List<IManagement>();

		/// <summary>
		/// Descriptor of the production activity
		/// </summary>
		public string ProductionActivity
		{
			get	{ return _productionActivity; }
			set { this._productionActivity = value; }
		}

		/// <summary>
		/// Rules to be tested
		/// </summary>
		public List<IRules> Rules
		{
			get	{ return _rules; }
			set { this._rules = value; }
		}

		/// <summary>
		/// Impacts to be published if rules are met
		/// </summary>
        public List<IManagement> Management
		{
			get	{ return _management; }
			set { this._management = value; }
		}
	}
}
