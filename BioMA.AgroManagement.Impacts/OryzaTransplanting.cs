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
  
    public  class OryzaTransplanting : IManagementTransplanting
    {

        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }

        #region Constructors
        /// <summary>
        /// Instance default constructor
        /// </summary>
        public OryzaTransplanting()
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
            foreach(XmlNode child in node.ChildNodes)
            {
                switch (child.Attributes["name"].InnerText)
                {
                    case ("SeedbedSowingDensity"):
                        _seedbedSowingDensity = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("FieldSowingDensity"):
                        _fieldSowingDensity = double.Parse(child.Attributes["value"].InnerText);
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
            writer.WriteAttributeString("name", "SeedbedSowingDensity");
            writer.WriteAttributeString("value", _seedbedSowingDensity.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "FieldSowingDensity");
            writer.WriteAttributeString("value", _fieldSowingDensity.ToString());
            writer.WriteEndElement();
        }
        #endregion

        #endregion

        #region IManagementCrop Members
        private double _seedbedSowingDensity;

        public double SeedbedSowingDensity
        {
            get { return _seedbedSowingDensity; }
            set { _seedbedSowingDensity = value; }
        }

        private double _fieldSowingDensity;

        public double FieldSowingDensity
        {
            get { return _fieldSowingDensity; }
            set { _fieldSowingDensity = value; }
        }


        #endregion

        #region Specific parameters

        

        #endregion    

        #region VarInfo methods and fields

        #region IDomainClass Members

        /// <summary>
        /// Parameters for crop transplanting
        /// </summary>
        public string Description
        {
            get { return ("Parameters for transplanting"); }
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
            get { return "Transplanting"; }
        }

        #endregion

        #region Specific VarInfo parameters
        private static VarInfo _seedbedSowingDensityVarInfo = new VarInfo();
        //VariInfo properties
        /// <summary>
        /// Sowing density of seedbed
        /// </summary>
        public static VarInfo SeedbedSowingDensityVarInfo
        {
            get { return _seedbedSowingDensityVarInfo; }
        }

        private static VarInfo _fieldSowingDensityVarInfo = new VarInfo();
        //VariInfo properties
        /// <summary>
        /// Sowing density of field
        /// </summary>
        public static VarInfo FieldSowingDensityVarInfo
        {
            get { return _fieldSowingDensityVarInfo; }
        }
        // VarInfo of parameters go here

        private static void SetParameterDescription()
        {
            _seedbedSowingDensityVarInfo.Name = "SeedbedSowingDensity";
            _seedbedSowingDensityVarInfo.Description = "Sowing density of seedbed";
            _seedbedSowingDensityVarInfo.MaxValue = 2000;
            _seedbedSowingDensityVarInfo.MinValue = 200;
            _seedbedSowingDensityVarInfo.DefaultValue = 800;
            _seedbedSowingDensityVarInfo.VarType = VarInfo.Type.PARAMETER;
            _seedbedSowingDensityVarInfo.Units = "unitless";
            _seedbedSowingDensityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");


            _fieldSowingDensityVarInfo.Name = "FieldSowingDensity";
            _fieldSowingDensityVarInfo.Description = "Sowing density of field";
            _fieldSowingDensityVarInfo.MaxValue = 500;
            _fieldSowingDensityVarInfo.MinValue = 80;
            _fieldSowingDensityVarInfo.DefaultValue = 250;
            _fieldSowingDensityVarInfo.VarType = VarInfo.Type.PARAMETER;
            _fieldSowingDensityVarInfo.Units = "unitless";
            _fieldSowingDensityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }
        #endregion

        #region Test preconditions
        private string VerifyPreconditions(string callID)
        {
            SetParametersInputsCurrentValue();

            /* 29/05/2012 old preconditions API - begin */
            //PreconditionsData prc = new PreconditionsData();
            //Preconditions pre = new Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(CropTransplanting.GreenLeafAreaIndexVarInfo);
            //prc.RangeBased.Add(CropTransplanting.GreenLeafAreaIndexVarInfo);
            //prc.RangeBased.Add(CropTransplanting.LatencyAfterTransplantVarInfo);
            //prc.RangeBased.Add(CropTransplanting.LeavesBiomassVarInfo);
            //prc.RangeBased.Add(CropTransplanting.RootDepthVarInfo);
            //prc.RangeBased.Add(CropTransplanting.SpecificLeafAreaVarInfo);
            //prc.RangeBased.Add(CropTransplanting.StorageOrgansBiomassVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != String.Empty) {pre.TestsOut(result, true, "Component CRA.AgroManagement.Impacts.dll, class CropTransPlanting"); }


            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
           prc.AddCondition(new RangeBasedCondition(_seedbedSowingDensityVarInfo));
           prc.AddCondition(new RangeBasedCondition(_fieldSowingDensityVarInfo));
           
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != String.Empty) { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class CropTransPlanting"); }
            /* 29/05/2012 new preconditions API - end */
            
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            _seedbedSowingDensityVarInfo.CurrentValue = _seedbedSowingDensity;
            _fieldSowingDensityVarInfo.CurrentValue = _fieldSowingDensity;
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
