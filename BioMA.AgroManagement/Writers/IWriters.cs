using System;
using System.IO;
using CRA.AgroManagement;

namespace CRA.AgroManagement.Writers
{
	/// <summary>
	/// Interface to be implemented by writers of applied management records
	/// </summary>
	public interface IWriters
	{
		/// <summary>
		/// Open the file/stream/connection
		/// </summary>
		/// <param name="sink"></param>
		void OpenWriter(object sink);

		/// <summary>
		/// Write relevant impact name and properties value each time 
		/// a rule is satisfied
		/// </summary>
		/// <param name="act">object containing an arraylist of IManagemnt</param>
		/// <param name="callID">identifier from the caller</param>
		void WriteManagementRecord(ActEvents act, string callID);  

		/// <summary>
		/// Close the file/stream/connection 
		/// </summary>
		void CloseWriter();
	}
}
