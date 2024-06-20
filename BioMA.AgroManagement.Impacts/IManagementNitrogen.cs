using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for mineral nitrogen management impact classes 
	/// </summary>
    public interface IManagementNitrogen : IManagement
	{
		/// <summary>Amount of nitrogen in nitrate form</summary>
        double TotalNitrateAmount { get; set; }

        /// <summary>Amount of nitrogen in ammonia form</summary>
        double TotalAmmoniaAmount { get; set; }

        /// <summary>True if fertlizer broadcasted on soil surface with no tillage</summary>
		bool SurfaceBroadcast { get; set; }
	}
}
