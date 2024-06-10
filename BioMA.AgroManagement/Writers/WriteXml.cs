using System;
using System.Collections;
using System.Xml;
using System.IO;

using CRA.AgroManagement;

namespace CRA.AgroManagement.Writers
{
	/// <summary>
	/// Writer to save impacts published and their values as XML file
	/// </summary>
	public class WriteXml : IWriters
	{
		private XmlTextWriter writer = null;

		#region IWriters Members

		/// <summary>
		/// Open the file/stream/connection
		/// </summary>
		/// <param name="sink">xml file name</param>
		public void OpenWriter(object sink)
		{
			writer = new XmlTextWriter(sink.ToString(), null);
			writer.Formatting = Formatting.Indented;

			writer.WriteStartDocument(true);
			writer.WriteStartElement("", "AgroManagementOutput","http://www.isci.it/tools");
			writer.WriteComment("Applied management events");
		}

		/// <summary>
		/// Write relevant impact name and properties value each time 
		/// a rule is satisfied
		/// </summary>
		/// <param name="act">object containing an arraylist of IManagemnt</param>
		/// <param name="callID">identifier from the caller</param>
		public void WriteManagementRecord(ActEvents act, string callID)
		{
			try
			{
				if (act.Management.Count != 0)
				{
				    callID.Replace("/", "-");
					writer.WriteStartElement("CallerIdentifier");
					writer.WriteAttributeString("value", callID);
					foreach (IManagement mg in act.Management)
					{
						writer.WriteStartElement("Impact");
						writer.WriteAttributeString("class", mg.ToString());
						mg.SaveXml(writer);
						writer.WriteEndElement();
					}
					writer.WriteEndElement();
				}
			}
			catch (Exception err)
			{
				throw new Exception("Failed to write XML file" + err.Message);
			}
		}
		
		/// <summary>
		/// Flush to stream and close the file 
		/// </summary>
		public void CloseWriter()
		{
			try
			{
				writer.WriteEndElement();
				writer.WriteEndDocument();
				writer.Flush();
				writer.Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Exception on closing Xml doc - " + ex.Message);
			}
		}

		#endregion

	}
}
