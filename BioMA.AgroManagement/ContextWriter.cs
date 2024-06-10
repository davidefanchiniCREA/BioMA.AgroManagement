using System;
using CRA.AgroManagement.Writers;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Summary description for ContextWriter.
	/// </summary>
	internal class ContextWriter
	{
		internal ContextWriter(IWriters w)
		{
			wr = w;
		}

		private IWriters wr;

		internal void WriteOut(ActEvents act, string callID)
		{
			wr.WriteManagementRecord(act, callID);
		}
	}
}
