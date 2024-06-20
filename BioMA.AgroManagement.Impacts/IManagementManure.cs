using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for organic nitrogen management impact classes 
	/// </summary>
    public interface IManagementManure : IManagement
	{
		/// <summary>Fresh weight of manure</summary>
        double TotalAmount { get; set; }
		
        /// <summary>Fraction of dry matter</summary>
        double DryMatterFraction { get; set; }

        /// <summary>True if manure applied to soil surface with no tillage following</summary>
		bool SurfaceBroadcast { get; set; }
	}
}
