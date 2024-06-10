using System;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Summary description for IScheduling.
	/// </summary>
	public interface IScheduling
	{
		/// <summary>
		/// A class implementing ISCheduling will be used at run-time to test rules
		/// </summary>
		/// <param name="sc">type with array lists of rules and managemnt events</param>
		/// <param name="s">states of the system, can be extended</param>
		void Update(SchEvents sc, AStatesAgroMan s);
	}
}
