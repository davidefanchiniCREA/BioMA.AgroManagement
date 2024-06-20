using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for irrigation management impact classes 
	/// </summary>
    public interface IManagementIrrigation : IManagement
	{
		/// <summary>Amount of water to be applied</summary>
        double IrrigationVolume {get; set;}
	}
}

