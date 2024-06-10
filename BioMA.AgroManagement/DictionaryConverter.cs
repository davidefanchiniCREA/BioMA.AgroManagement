using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace CRA.AgroManagement
{
    /// <summary>
    /// This class links a value type variable (such as Irrigationtype) to the 
    /// corresponding Key-Value map (such as IrrigationMethods)
    /// </summary>
    public class DictionaryConverter : StringConverter
    {

		/// <summary>
		/// Static variable used to store a map and to avoid repeated loads
		/// </summary>
		private static Dictionary<string, string> tempMap = null;

		private static string tempProperty = null;

		/// <summary>
		/// Override of StringConverter.GetStandardValuesSupported base class method
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

		/// <summary>
		/// Override of StringConverter.GetStandardValues base class method
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
			Dictionary<string, string> map = getMap( context );
			if (map != null)
			{
				string[] values = new string[map.Count];
				int i = 0;
				foreach (KeyValuePair<string, string> kv in map)
					values[i++] = "[" + kv.Key + "]" + " " + kv.Value;
				return new StandardValuesCollection( values );
			}

            return null;
			
        }

		/// <summary>
		/// Override of StringConverter.ConvertTo base class method
		/// </summary>
		/// <param name="context"></param>
		/// <param name="culture"></param>
		/// <param name="value"></param>
		/// <param name="destinationType"></param>
		/// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value != null )
            {
				Dictionary<string, string> map = getMap( context );
				if (map != null)
				{
					string key = (string)value;
					if (key.Contains( "[" ) && key.Contains( "]" ))
						return key;
					else
						return "[" + key + "]" + " " + map[key];
				}
            }
            
			return null;
        }

		/// <summary>
		/// Override of StringConverter.CanConvertFrom" base class method
		/// </summary>
		/// <param name="context"></param>
		/// <param name="sourceType"></param>
		/// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

		/// <summary>
		/// Override of StringConverter.ConvertFrom base class method
		/// </summary>
		/// <param name="context"></param>
		/// <param name="culture"></param>
		/// <param name="value"></param>
		/// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
			if (value is string)
			{
				Dictionary<string, string> map = getMap( context );
				if (map != null)
				{
					string item = (string)value;
					string key = item.Substring( item.IndexOf( "[" ) + 1, item.IndexOf( "]" ) - 1 );


					if (map.ContainsKey( key ))
					{
						return key;
					}
					else
						return base.ConvertFrom( context, culture, value );
				}
			}
			
            return base.ConvertFrom(context, culture, value);
        }

		/// <summary>
		/// Reads via reflection and instantiates the map linked 
		/// (via <see cref="ImpactMapAttribute">ImpactMapAttribute</see> attribute class)
		/// to a specific property
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private Dictionary<string, string> getMap( ITypeDescriptorContext context )
		{
			if (context == null)
				return null;

			
			Type type = context.Instance.GetType();
            PropertyInfo prop = type.GetProperty(context.PropertyDescriptor.Name);
			if (prop != null)
			{
				if (prop.GetCustomAttributes( typeof( ImpactMapAttribute ), false ).Length > 0)
				{
					try
					{
						object[] laAttributes = prop.GetCustomAttributes( typeof( ImpactMapAttribute ), false );

						ImpactMapAttribute ima = (ImpactMapAttribute)laAttributes[0];

                        //if (ima.PropertyName == tempProperty)
                        //    return tempMap;

						
						string qualifiedName = Assembly.CreateQualifiedName( ima.AssemblyName, ima.ClassName );

						//check if already in memory; if not, load the assembly
						if (Type.GetType( qualifiedName ) == null)
						{
							Assembly.Load( ima.AssemblyName );
						}

						PropertyInfo instance = Type.GetType( qualifiedName ).GetProperty(
							ima.PropertyName );

						object obj = Type.GetType( qualifiedName ).GetConstructor( new Type[] { } ).Invoke( null );

						Dictionary<string, string> map = (Dictionary<string, string>)((ImpactMap)
							instance.GetValue( obj, null )).Map;

						//update static temporary values
						tempProperty = ima.PropertyName;
						tempMap = map;

						return map;
					}
					catch(Exception ex)
					{
						Console.Out.WriteLine( ex.Message );
						return null;
					}
				}
			}

			return null;
		}
    }
}
