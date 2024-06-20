using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for clipping management impact classes 
	/// </summary>
    public interface IManagementWaterLevel : IManagement
	{
		/// <summary>Water level to be applied</summary>
		double WaterLevel { get; set; }
	}
}
