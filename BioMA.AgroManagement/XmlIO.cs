using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Reflection;
using System.Collections;

namespace CRA.AgroManagement
{
	
    /// <summary>
    /// Constants of the AgroManagement component
    /// </summary>
    public class XmlIO
	{
		private XmlIO()
		{ }

		#region Common constants

		/// <summary>
		/// Constants containing the current directory of the CRA.AgroManagement2014.dll
		/// </summary>
		public static string AGROMANAGEMENT_DIR = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

		/// <summary>
		/// Url used as reference for the impact enumeration files
		/// </summary>
		public const string IMPACT_DATA_SCHEMA = "http://seamless.org/AgroManagementImpactData.xsd";

		/// <summary>
		/// Directory containing all the Xml Schemas (xsd) for the AgroManagement System
		/// </summary>
		public const string XML_SCHEMAS_PATH = "xmlSchema";

		#endregion

		#region AgroManagement configuration file constants

		/// <summary>
		/// The name of the AgroManagement configuration file
		/// </summary>
		public const string CONFIG_FILE = "AgroManagementConfig.xml";

		/// <summary>
		/// The tag of the Xml element containing the references to external assemblies
		/// </summary>
		public const string EXTERNAL_ASSEMBLIES_TAG = "ExternalAssemblies";

		/// <summary>
		/// The tag of the Xml element containing a single external assembly
		/// </summary>
		public const string ASSEMBLY_TAG = "Assembly";
		
		/// <summary>
		/// Url used as reference for the AgroManagement configuration file
		/// </summary>
		public const string AGROMANAGEMENT_CONFIG_SCHEMA = "http://seamless.org/AgroManagementConfig.xsd";

		/// <summary>
		/// Name of the Xml Schema for AgroManegement configuration file
		/// </summary>
		public const string XML_SCHEMAS_AGROMANAGEMENT_CONFIG_FILE = "AgroManagementConfig.xsd";
		
		/// <summary>
		/// Name of the attribute "type"
		/// </summary>
		public const string ATTRIBUTE_TYPE = "type";

		/// <summary>
		/// Value of the attribute "type" for Rule assemblies
		/// </summary>
		public const string ATTRIBUTE_TYPE_RULES = "rules";

		/// <summary>
		/// Value of the attribute "type" for Impact assemblies
		/// </summary>
		public const string ATTRIBUTE_TYPE_IMPACTS = "impacts";

		#endregion

		#region Impact data file constants

		/// <summary>
		/// Name of the Xml Schema for impact enumeration files
		/// </summary>
		public const string XML_SCHEMAS_IMPACT_DATA_FILE = "AgroManagementImpactData.xsd";

		/// <summary>
		/// Name of the attribute "name"
		/// </summary>
		public const string ATTRIBUTE_NAME = "name";

		/// <summary>
		/// Name of the Root element of impact enumeration files
		/// </summary>
		public const string XML_LIST_DOCUMENT_ELEMENT = "AgroManagementImpactData";

		#endregion
	}
}
