using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
	/// <summary>
	/// Interface for crop management impact classes 
	/// </summary>
    public interface IManagementCrop : IManagement
	{
		/// <summary>Crop name</summary>
        string CropName {get; set;}

        /// <summary> Crop operation</summary>
		string CropOperation {get; set;}
	}
}
