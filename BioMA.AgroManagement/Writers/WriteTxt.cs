using System;
using System.Reflection;
using System.IO;

using CRA.AgroManagement;

namespace CRA.AgroManagement.Writers
{
	/// <summary>
	/// Writer to save impacts published and their values as TXT file
	/// </summary>
	public class WriteTxt : IWriters	
	{

		private StreamWriter writer = null;

		#region IWriters Members

		/// <summary>
		/// Open the file/stream/connection
		/// </summary>
		/// <param name="sink">file path</param>
		public void OpenWriter(object sink)
		{
			writer = new StreamWriter(sink.ToString(),false);
		}

		/// <summary>
		/// Flush to stream and close the file 
		/// </summary>
		public void CloseWriter()
		{
			try
			{
				writer.Flush();
				writer.Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Exception on closing the TXT output file - " + ex.Message);
			}
		}

		/// <summary>
		/// Write relevant impact name and properties value each time 
		/// a rule is satisfied
		/// </summary>
		/// <param name="act">object containing an arraylist of IManagemnt</param>
		/// <param name="callID">identifier from the caller</param>
		public void WriteManagementRecord(ActEvents act, string callID)
		{
            writer.WriteLine("-- Caller identifier:" + callID + "--");			
			foreach (IManagement m in act.Management)
			{
				writer.WriteLine("Impact class: " + m.ToString());
				Type t = m.GetType();
				PropertyInfo[] p = t.GetProperties();
				object val = new object();
				foreach(PropertyInfo pr in p)
				{
                    if (!pr.Name.EndsWith("VarInfo") & 
                        !pr.Name.Contains("Map") & 
                        !pr.Name.Contains("URL") &
                        !pr.Name.Contains("DomainClassOfReference"))
					{
						try
						{
							val = pr.GetValue(m, System.Reflection.BindingFlags.GetProperty,null, null, null);
							writer.WriteLine(" " + pr.Name.ToString() + " = " + val.ToString());
						}
						catch (Exception err)
						{
							throw new Exception("Failed to get property value and write it on stream, AgroManagement component, WriteTxt class" + err.Message, err); 
						}
					}
				}
			}
		}
		#endregion
	}
}
