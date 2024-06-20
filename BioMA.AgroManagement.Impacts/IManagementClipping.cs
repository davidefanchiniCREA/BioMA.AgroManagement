using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for clipping management impact classes 
	/// </summary>
    public interface IManagementClipping : IManagement
	{
		/// <summary>Percentage of residuals</summary>
		double PercentageOfResidues { get; set; }
	}
}
