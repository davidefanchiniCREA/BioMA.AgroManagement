using System;
using System.Xml;
//using CRA.AgroManagement.impacts;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;

namespace CRA.AgroManagement
{
	/// <summary>
	/// IRules is the interface that all rules must implement
	/// </summary>
    public interface IRules : IStrategy, IVarInfoClass
    {

        /// <summary>
		///  the rotation year
		/// </summary>
		int RotationYear { get; set;}

		/// <summary>
		/// impact to be coupled to the rule
		/// </summary>
		string ImpactDependency { get; }

		/// <summary>
		/// Rule classes must implemnt this interface.
		/// A rule may or may not write parameters values
		/// </summary>
		/// <param name="st">states of the system, can be extended</param>
		/// <param name="m">management type</param>
		/// <returns>true if rules are matched</returns>
		bool CheckRule(StatesAgroMan st, IManagement m);
		
		/// <summary>
		/// Test preconditions of parameters internal to the rule
		/// It is assumed that states are tested by other components 
		/// </summary>
		/// <param name="m">management type</param>
		/// <param name="callID"></param>
		string TestPreConditions(IManagement m, string callID);

		/// <summary>
		/// Reads management content from a XmlNode
		/// </summary>
		/// <param name="node">xml node containing instance data</param>
		void LoadXml(XmlNode node);

		/// <summary>
		/// Stores actual data in a passed xml file
		/// </summary>
		/// <param name="writer"></param>
		void SaveXml(XmlTextWriter writer);
	}
}
