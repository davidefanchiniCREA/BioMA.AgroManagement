using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	///Interface for water level management impact classes 
	/// </summary>
	public interface IManagementTransplanting : IManagement
	{
		/// <summary>Seedbed sowing density</summary>
		double SeedbedSowingDensity { get; set; }

		/// <summary>Field sowing density</summary>
		double FieldSowingDensity { get; set; }
	}
}
