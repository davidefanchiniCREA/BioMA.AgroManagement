using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.ComponentModel;


namespace CRA.AgroManagement
{
	/// <summary>
	/// Class used to store a specif map and read its values from an xml file
	/// </summary>
	public class ImpactMap
    {
        #region Constructor
        /// <summary>
		/// Mapping file name to a specific property
		/// </summary>
		/// <param name="_fileName">The name of the XML file associated</param>
		/// <param name="_name">The name of the map</param>
		//public ImpactMap( string _fileName, string _name )
        public ImpactMap(string _fileName, string _name)	
    {
			_xmlMapFileName = _fileName;

			_mapName = _name;

			_map = ReadEnumTypes( _xmlMapFileName, _mapName );
        }
        #endregion

        #region Properties

        private Dictionary<string, string> _map = null;
		/// <summary>
		/// The internal Key-Value Map
		/// </summary>
		public Dictionary<string, string> Map
		{
			get
			{
				return _map;
			}
			set
			{
				_map = value;
			}
		}
		
		private string _xmlMapFileName = null;
		/// <summary>
		/// XML file name with list values which can be assigned to a property
		/// </summary>
		public string XmlMapFileName
		{
			get
			{
				return _xmlMapFileName;
			}
		}

		private string _mapName = null;
		/// <summary>
		/// Name of the tag inside the <see cref="XmlMapFileName">XmlMapFileName</see>
		/// in which are stored the Key-Value pairs
		/// </summary>
		private string MapName
		{
			get
			{
				return _mapName;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Method used to read an xml File containing a Key-Value map
		/// </summary>
		/// <param name="xmlPathType">The xml path name</param>
		/// <param name="MapName">The internal xml tag name in which there are Key-Value pairs</param>
		/// <returns></returns>
		public Dictionary<string,string> ReadEnumTypes( string xmlPathType, string MapName)
		{
			// Create the parser
			// Create the XmlSchemaSet class
			XmlSchemaSet sc = new XmlSchemaSet();

			//check where is the schema file
			string path = null;
			if (System.IO.File.Exists(
					XmlIO.AGROMANAGEMENT_DIR +
					System.IO.Path.DirectorySeparatorChar +
					XmlIO.XML_SCHEMAS_PATH +
					System.IO.Path.DirectorySeparatorChar +
					XmlIO.XML_SCHEMAS_IMPACT_DATA_FILE ))
				
				path = XmlIO.AGROMANAGEMENT_DIR +
				System.IO.Path.DirectorySeparatorChar +
				XmlIO.XML_SCHEMAS_PATH +
				System.IO.Path.DirectorySeparatorChar +
				XmlIO.XML_SCHEMAS_IMPACT_DATA_FILE;

			else if (System.IO.File.Exists(
					XmlIO.AGROMANAGEMENT_DIR +
					System.IO.Path.DirectorySeparatorChar +
					XmlIO.XML_SCHEMAS_IMPACT_DATA_FILE ))
				
				path = XmlIO.AGROMANAGEMENT_DIR +
				System.IO.Path.DirectorySeparatorChar +
				XmlIO.XML_SCHEMAS_IMPACT_DATA_FILE;

			// Add the schema to the collection
			sc.Add( XmlIO.IMPACT_DATA_SCHEMA,
				path);

			// Set the validation settings
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ValidationType = ValidationType.Schema;
			settings.Schemas = sc;

			string dir = XmlIO.AGROMANAGEMENT_DIR +
				System.IO.Path.DirectorySeparatorChar +
				xmlPathType;

			// Create the XmlReader and XmlDocument objects
			XmlReader reader = XmlReader.Create( dir, settings );
			XmlDocument doc = new XmlDocument();

			//temp variable
			Dictionary<string, string> temp = null;
			try
			{
				// Read the template
				doc.Load( reader );

				if (doc.DocumentElement.Name != XmlIO.XML_LIST_DOCUMENT_ELEMENT)
				{
					return null;
				}

				// Fill data structure
				foreach (XmlNode type in doc.DocumentElement.ChildNodes)
				{
					if (type.NodeType != XmlNodeType.Element)
					{
						continue;
					}

					temp = new Dictionary<string, string>();

					//retrieve the property; if value is not present it returns null
					string mapName = type.Attributes[XmlIO.ATTRIBUTE_NAME].Value;
					if (mapName != null && MapName == mapName)
					{

						//read the dictionary values as a pair
						foreach (XmlNode data in type.ChildNodes)
						{
							if (data.NodeType != XmlNodeType.Element)
							{
								continue;
							}
							//key
							string name = data.Attributes[XmlIO.ATTRIBUTE_NAME].Value.ToString();
							//value
							string description = data.InnerText;

							temp.Add( name, description );
						}

						//ok, the map was found
						return temp;
					}
				}

				//nothing found
				return null;
			}
			catch (XmlException ex)
			{
				Console.WriteLine( "Either the Xml is not present or it is not well-formed.\n" +
					"Empty data were used.", ex);
				return null;
			}
		}

		#endregion
	}
}
