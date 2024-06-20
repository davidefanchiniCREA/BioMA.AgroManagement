using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for tillage management impact classes 
	/// </summary>
    public interface IManagementTillage : IManagement
	{
		/// <summary>Mean tillage depth</summary>
        double MeanTillageDepth {get; set;}
	}
		
}