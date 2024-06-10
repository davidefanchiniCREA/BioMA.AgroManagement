using System;

namespace CRA.AgroManagement
{
	/// <summary>
	/// This Class creates an Attribute by which the user can specify 
	/// an assembly name, a full class name and the name of the map property
	/// </summary>
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false)]
    public class ImpactMapAttribute: Attribute
    {
       
        private string _assemblyName;
        /// <summary>
        /// The name of the assembly containing the Key-Value map
        /// </summary>
        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }

        private string _className;
        /// <summary>
		/// The full name (including the namespace) of the Class in which there is
		/// the Key-Value map
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private string _propertyName;
        /// <summary>
        /// The property name containing the Key-Value map
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        /// <summary>
        /// Parameter Constructor
        /// </summary>
        /// <param name="assemblyName">The assembly name passed through the attribute declaration</param>
		/// <param name="className">The full class name passed through the attribute declaration</param>
		/// <param name="propertyName">The property name containing the Key-Value map passed through the attribute declaration</param>
        public ImpactMapAttribute(string assemblyName, string className, string propertyName)
        {
            _assemblyName = assemblyName;
            _className = className;
            _propertyName = propertyName;
        }
    }
}
