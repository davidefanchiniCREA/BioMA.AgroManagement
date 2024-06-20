using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.ComponentModel;

using CRA.AgroManagement;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;


namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    /// CropTransplanting implements a set of parameters to transplant a crop according to Oryza model
    /// </summary>
  
    public  class Clipping : IManagementClipping
    {

        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }

        #region Constructors
        /// <summary>
        /// Instance default constructor
        /// </summary>
        public Clipping()
        {
            SetParameterDescription();
            _managementType = AManagementTypes.ManagType.CROP_OPERATION;
            _io = new ParametersIO(this);
        }
        #endregion

        #region IManagement Members
        private AManagementTypes.ManagType _managementType;
        /// <summary>
        /// managemnt type from AManagementTypes.cs
        /// </summary>
        public AManagementTypes.ManagType ManagementType
        {
            get { return _managementType; }
        }
        /// <summary>
        /// test of pre-conditions
        /// </summary>
        /// <param name="callID">identifier from caller</param>
        /// <returns>pre-conditions violated</returns>
        public string TestPreconditions(string callID)
        {
            return VerifyPreconditions(callID);
        }

        #region Xml management
        /// <summary>
        /// Reads management content from a XmlNode
        /// </summary>
        /// <param name="node">xml node containing instance data</param>
        public void LoadXml(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                switch (child.Attributes["name"].InnerText)
                {
                    case ("PercentageOfResidues"):
                        _percentageOfResidues = double.Parse(child.Attributes["value"].InnerText);
                        break;
                }
            }
        }

        /// <summary>
        /// Stores actual data in a passed xml file
        /// </summary>
        /// <param name="writer"></param>
        public void SaveXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "PercentageOfResidues");
            writer.WriteAttributeString("value", _percentageOfResidues.ToString());
            writer.WriteEndElement();

        }
        #endregion

        #endregion

        #region IManagementWaterLevel Members

        private double _percentageOfResidues;

        public double PercentageOfResidues
        {
            get { return _percentageOfResidues; }
            set { _percentageOfResidues = value; }
        }




        #endregion

        #region Specific parameters

        // Parameters can be added here

        #endregion

        #region VarInfo methods and fields

        #region IDomainClass Members

        /// <summary>
        /// Parameters for clipping
        /// </summary>
        public string Description
        {
            get { return ("Parameters for clipping"); }
        }

        /// <summary>
        /// Domain class description on the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless-ip.org"; }
        }

        #endregion

        #region IVarInfoClass Members

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "Clipping"; }
        }

        #endregion

        #region Specific VarInfo parameters

        private static VarInfo _percentageOfResiduesVarInfo = new VarInfo();
        //VariInfo properties
        /// <summary>
        /// Percentage of residues
        /// </summary>
        public static VarInfo PercentageOfResiduesVarInfo
        {
            get { return _percentageOfResiduesVarInfo; }
        }



        #endregion

        #region Parameters description
        private void SetParameterDescription()
        {
            _percentageOfResiduesVarInfo.Name = "PercentageOfResidues";
            _percentageOfResiduesVarInfo.Description = "Percentage of residues left in the field";
            _percentageOfResiduesVarInfo.MaxValue = 100;
            _percentageOfResiduesVarInfo.MinValue = 1;
            _percentageOfResiduesVarInfo.DefaultValue = 5;
            _percentageOfResiduesVarInfo.VarType = VarInfo.Type.PARAMETER;
            _percentageOfResiduesVarInfo.Units = "%";
            _percentageOfResiduesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");


        }
        #endregion

        #region Test preconditions
        private string VerifyPreconditions(string callID)
        {
            SetParametersInputsCurrentValue();
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_percentageOfResiduesVarInfo));

            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != String.Empty) { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class CropTransPlanting"); }
            /* 29/05/2012 new preconditions API - end */

            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _percentageOfResiduesVarInfo.CurrentValue = _percentageOfResidues;
        }
        #endregion

        #endregion

        public IList<string> StrategyUsed
        {
            get { return new List<string>(); }
        }


        #region Implementation of IDomainClass

        private readonly ParametersIO _io;
        public IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {

                return _io.GetCachedProperties(typeof(IDomainClass));
            }
        }

        public bool ClearValues()
        {
            return true;
        }

        #endregion
    }
}
