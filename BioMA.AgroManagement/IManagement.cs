using System;
using System.Xml;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Base interface for impact classes, implemented via management specific interfaces
	/// </summary>
    public interface IManagement : IManagementBase
    {
        /// <summary>
		/// Enumerator management type
		/// </summary>
		CRA.AgroManagement.AManagementTypes.ManagType ManagementType { get; }
		
		
	
	}
}
