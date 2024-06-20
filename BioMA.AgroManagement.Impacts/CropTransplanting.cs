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
    /// CropTransplanting implements a set of parameters to transplant a crop 
    /// </summary>
  
    public  class CropTransplanting : IManagementCrop
    {
        public CRA.ModelLayer.Core.ITestsOutput PreconditionsWriter { get; set; }
        #region Costants

        /// <summary>
        /// Tag for implement element name in xmlMapFile
        /// </summary>
        public const string XML_ELEMENT_NAME = "CropName";

        /// <summary>
        /// xmlMapFile file name
        /// </summary>
        public const string XML_MAP_FILENAME = "Crops_1.xml";

        #endregion

        #region Constructors
        /// <summary>
        /// Instance default constructor
        /// </summary>
        public CropTransplanting()
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
                    case ("CropName"):
                        _cropName = child.Attributes["value"].InnerText;
                        break;
					case ("CropOperation"):
						_cropOperation = child.Attributes["value"].InnerText;
						break;
                    case ("GreenLeafAreaIndex"):
                        _GreenLeafAreaIndex = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("TotalLeafAreaIndex"):
                        _TotalLeafAreaIndex = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("AbovegroundBiomass"):
                        _AbovegroundBiomass = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("LeavesBiomass"):
                        _LeavesBiomass = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("StemsBiomass"):
                        _StemsBiomass = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("StorageOrgansBiomass"):
                        _StorageOrgansBiomass = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("SpecificLeafArea"):
                        _SpecificLeafArea = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("RootDepth"):
                        _RootDepth = double.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("LatencyAfterTransplant"):
                        _LatencyAfterTransplant = int.Parse(child.Attributes["value"].InnerText);
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
            writer.WriteAttributeString("name","CropName");
            writer.WriteAttributeString("value", _cropName);
            writer.WriteEndElement();
			
			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","CropOperation");
			writer.WriteAttributeString("value", _cropOperation);
			writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "GreenLeafAreaIndex");
            writer.WriteAttributeString("value", _GreenLeafAreaIndex.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "TotalLeafAreaIndex");
            writer.WriteAttributeString("value", _TotalLeafAreaIndex.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "AbovegroundBiomass");
            writer.WriteAttributeString("value", _AbovegroundBiomass.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "LeavesBiomass");
            writer.WriteAttributeString("value", _LeavesBiomass.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "StemsBiomass");
            writer.WriteAttributeString("value", _StemsBiomass.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "StorageOrgansBiomass");
            writer.WriteAttributeString("value", _StorageOrgansBiomass.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "SpecificLeafArea");
            writer.WriteAttributeString("value", _SpecificLeafArea.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "RootDepth");
            writer.WriteAttributeString("value", _RootDepth.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "LatencyAfterTransplant");
            writer.WriteAttributeString("value", _LatencyAfterTransplant.ToString());
            writer.WriteEndElement();			
        }
        #endregion

        #endregion

        #region IManagementCrop Members
        private string _cropName;			           
        /// <summary>
        /// Crop name
        /// </summary>
        [ImpactMap("BioMA.AgroManagement.Impacts", "CRA.AgroManagement.Impacts.CropTransplanting", "CropNameMap")]
        [TypeConverter(typeof(DictionaryConverter))]
        public string CropName
        {
            get { return _cropName; }
            set { _cropName = value; }
        }

        private ImpactMap _cropNameMap = null;
        /// <summary>
        /// Map to associate enum value to its description
        /// </summary>
        [Browsable(false)]
        public ImpactMap CropNameMap
        {
            get
            {
                if (_cropNameMap == null)
                {
                    _cropNameMap = new ImpactMap
                        (CropPlanting.XML_MAP_FILENAME,
                         CropPlanting.XML_ELEMENT_NAME);
                }
                return _cropNameMap;
            }
        }

		private string _cropOperation;					
		/// <summary>
		/// Crop operation type
		/// </summary>
		public string CropOperation
		{
			get { return _cropOperation; }
			set { _cropOperation = value; }
		}
        #endregion
	    
        #region Specific parameters

        private double _GreenLeafAreaIndex;
        private double _TotalLeafAreaIndex;
        private double _AbovegroundBiomass;
        private double _LeavesBiomass;
        private double _StemsBiomass;
        private double _StorageOrgansBiomass;
        private double _SpecificLeafArea;
        private double _RootDepth;
        private int _LatencyAfterTransplant;
        private static VarInfo _GreenLeafAreaIndexVarInfo = new VarInfo();
        private static VarInfo _TotalLeafAreaIndexVarInfo = new VarInfo();
        private static VarInfo _AbovegroundBiomassVarInfo = new VarInfo();
        private static VarInfo _LeavesBiomassVarInfo = new VarInfo();
        private static VarInfo _StemsBiomassVarInfo = new VarInfo();
        private static VarInfo _StorageOrgansBiomassVarInfo = new VarInfo();
        private static VarInfo _SpecificLeafAreaVarInfo = new VarInfo();
        private static VarInfo _RootDepthVarInfo = new VarInfo();
        private static VarInfo _LatencyAfterTransplantVarInfo = new VarInfo();

        /// <summary>
        /// Latency after transplant
        /// </summary>
        public int LatencyAfterTransplant
        {
            get { return _LatencyAfterTransplant; }
            set { _LatencyAfterTransplant = value; }
        }

        /// <summary>
        /// Root depth
        /// </summary>
        public double RootDepth
        {
            get { return _RootDepth; }
            set { _RootDepth = value; }
        }

        /// <summary>
        /// Specific leaf area
        /// </summary>
        public double SpecificLeafArea
        {
            get { return _SpecificLeafArea; }
            set { _SpecificLeafArea = value; }
        }

        /// <summary>
        /// Storage organs biomass
        /// </summary>
        public double StorageOrgansBiomass
        {
            get { return _StorageOrgansBiomass; }
            set { _StorageOrgansBiomass = value; }
        }

        /// <summary>
        /// Stems biomass
        /// </summary>
        public double StemsBiomass
        {
            get { return _StemsBiomass; }
            set { _StemsBiomass = value; }
        }
        
        /// <summary>
        /// Leaves biomass
        /// </summary>
        public double LeavesBiomass
        {
            get { return _LeavesBiomass; }
            set { _LeavesBiomass = value; }
        }

        /// <summary>
        /// Above ground biomass
        /// </summary>
        public double AbovegroundBiomass
        {
            get { return _AbovegroundBiomass; }
            set { _AbovegroundBiomass = value; }
        }

        /// <summary>
        /// Total leaf area index
        /// </summary>
        public double TotalLeafAreaIndex
        {
            get { return _TotalLeafAreaIndex; }
            set { _TotalLeafAreaIndex = value; }
        }

        /// <summary>
        /// Green leaf area index
        /// </summary>
        public double GreenLeafAreaIndex
        {
            get { return _GreenLeafAreaIndex; }
            set { _GreenLeafAreaIndex = value; }
        }

        /// <summary>
        /// VarInfo of LatencyAfterTransplant
        /// </summary>
        public static VarInfo LatencyAfterTransplantVarInfo
        {
            get { return _LatencyAfterTransplantVarInfo; }
        }

        /// <summary>
        /// VarInfo of RootDepthVar
        /// </summary>
        public static VarInfo RootDepthVarInfo
        {
            get { return _RootDepthVarInfo; }
        }

        /// <summary>
        /// VarInfo of SpecificLeafArea
        /// </summary>
        public static VarInfo SpecificLeafAreaVarInfo
        {
            get { return _SpecificLeafAreaVarInfo; }
        }

        /// <summary>
        /// VarInfo of StorageOrgansBiomass
        /// </summary>
        public static VarInfo StorageOrgansBiomassVarInfo
        {
            get { return _StorageOrgansBiomassVarInfo; }
        }

        /// <summary>
        /// VarInfo of StemsBiomass
        /// </summary>
        public static VarInfo StemsBiomassVarInfo
        {
            get { return _StemsBiomassVarInfo; }
        }

        /// <summary>
        /// VarInfo of LeavesBiomass
        /// </summary>
        public static VarInfo LeavesBiomassVarInfo
        {
            get { return _LeavesBiomassVarInfo; }
        }

        /// <summary>
        /// VarInfo of AbovegroundBiomass
        /// </summary>
        public static VarInfo AbovegroundBiomassVarInfo
        {
            get { return _AbovegroundBiomassVarInfo; }
        }

        /// <summary>
        /// VarInfo of TotalLeafAreaIndex
        /// </summary>
        public static VarInfo TotalLeafAreaIndexVarInfo
        {
            get { return _TotalLeafAreaIndexVarInfo; }
        }

        /// <summary>
        /// VarInfo of GreenLeafAreaIndex
        /// </summary>
        public static VarInfo GreenLeafAreaIndexVarInfo
        {
            get { return _GreenLeafAreaIndexVarInfo; }
        }

        #endregion    

        #region VarInfo methods and fields

        #region IDomainClass Members

        /// <summary>
        /// Parameters for crop planting
        /// </summary>
        public string Description
        {
            get { return ("Parameters for crop transplanting"); }
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
            get { return "CRA.AgroManagement.Impacts.CropTransPlanting"; }
        }

        #endregion

        #region Specific VarInfo parameters

        // VarInfo of parameters go here

        private static void SetParameterDescription()
        {
            _GreenLeafAreaIndexVarInfo.Description = "Green leaf area index";
            _GreenLeafAreaIndexVarInfo.Name = "GreenLeafAreaIndex";
            _GreenLeafAreaIndexVarInfo.MaxValue = 25;
            _GreenLeafAreaIndexVarInfo.MinValue = 0;
            _GreenLeafAreaIndexVarInfo.DefaultValue = 2;
            _GreenLeafAreaIndexVarInfo.Units = "m2 m-2";
            _GreenLeafAreaIndexVarInfo.VarType = VarInfo.Type.PARAMETER;
            _GreenLeafAreaIndexVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TotalLeafAreaIndexVarInfo.Description = "Total leaf area index";
            _TotalLeafAreaIndexVarInfo.Name = "TotalLeafAreaIndex";
            _TotalLeafAreaIndexVarInfo.MaxValue = 25;
            _TotalLeafAreaIndexVarInfo.MinValue = 0;
            _TotalLeafAreaIndexVarInfo.DefaultValue = 2;
            _TotalLeafAreaIndexVarInfo.Units = "m2 m-2";
            _TotalLeafAreaIndexVarInfo.VarType = VarInfo.Type.PARAMETER;
            _TotalLeafAreaIndexVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AbovegroundBiomassVarInfo.Description = "Above ground biomass";
            _AbovegroundBiomassVarInfo.Name = "AbovegroundBiomass";
            _AbovegroundBiomassVarInfo.MaxValue = 50000;
            _AbovegroundBiomassVarInfo.MinValue = 0;
            _AbovegroundBiomassVarInfo.DefaultValue = 1500;
            _AbovegroundBiomassVarInfo.Units = "kg ha-1";
            _AbovegroundBiomassVarInfo.VarType = VarInfo.Type.PARAMETER;
            _AbovegroundBiomassVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _LeavesBiomassVarInfo.Description = "Leaves biomass";
            _LeavesBiomassVarInfo.Name = "LeavesBiomass";
            _LeavesBiomassVarInfo.MaxValue = 30000;
            _LeavesBiomassVarInfo.MinValue = 0;
            _LeavesBiomassVarInfo.DefaultValue = 1500;
            _LeavesBiomassVarInfo.Units = "kg ha-1";
            _LeavesBiomassVarInfo.VarType = VarInfo.Type.PARAMETER;
            _LeavesBiomassVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _StemsBiomassVarInfo.Description = "Stems biomass";
            _StemsBiomassVarInfo.Name = "StemsBiomass";
            _StemsBiomassVarInfo.MaxValue = 30000;
            _StemsBiomassVarInfo.MinValue = 0;
            _StemsBiomassVarInfo.DefaultValue = 1500;
            _StemsBiomassVarInfo.Units = "kg ha-1";
            _StemsBiomassVarInfo.VarType = VarInfo.Type.PARAMETER;
            _StemsBiomassVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _StorageOrgansBiomassVarInfo.Description = "Storage organs biomass";
            _StorageOrgansBiomassVarInfo.Name = "StorageOrgansBiomass";
            _StorageOrgansBiomassVarInfo.MaxValue = 30000;
            _StorageOrgansBiomassVarInfo.MinValue = 0;
            _StorageOrgansBiomassVarInfo.DefaultValue = 1500;
            _StorageOrgansBiomassVarInfo.Units = "kg ha-1";
            _StorageOrgansBiomassVarInfo.VarType = VarInfo.Type.PARAMETER;
            _StorageOrgansBiomassVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SpecificLeafAreaVarInfo.Description = "Storage organs biomass";
            _SpecificLeafAreaVarInfo.Name = "SpecificLeafArea";
            _SpecificLeafAreaVarInfo.MaxValue = 30;
            _SpecificLeafAreaVarInfo.MinValue = 12;
            _SpecificLeafAreaVarInfo.DefaultValue = 20;
            _SpecificLeafAreaVarInfo.Units = "m2 g-1";
            _SpecificLeafAreaVarInfo.VarType = VarInfo.Type.PARAMETER;
            _SpecificLeafAreaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _RootDepthVarInfo.Description = "Roots depth";
            _RootDepthVarInfo.Name = "RootDepth";
            _RootDepthVarInfo.MaxValue = 3;
            _RootDepthVarInfo.MinValue = 0;
            _RootDepthVarInfo.DefaultValue = 0.1;
            _RootDepthVarInfo.Units = "m";
            _RootDepthVarInfo.VarType = VarInfo.Type.PARAMETER;
            _RootDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _LatencyAfterTransplantVarInfo.Description = "Latency after transplant";
            _LatencyAfterTransplantVarInfo.Name = "LatencyAfterTransplant";
            _LatencyAfterTransplantVarInfo.MaxValue = 40;
            _LatencyAfterTransplantVarInfo.MinValue = 1;
            _LatencyAfterTransplantVarInfo.DefaultValue = 2;
            _LatencyAfterTransplantVarInfo.Units = "d";
            _LatencyAfterTransplantVarInfo.VarType = VarInfo.Type.PARAMETER;
            _LatencyAfterTransplantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
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
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.GreenLeafAreaIndexVarInfo));
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.GreenLeafAreaIndexVarInfo));
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.LatencyAfterTransplantVarInfo));
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.LeavesBiomassVarInfo));
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.RootDepthVarInfo));
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.SpecificLeafAreaVarInfo));
           prc.AddCondition(new RangeBasedCondition(CropTransplanting.StorageOrgansBiomassVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != String.Empty) { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Impacts.dll, class CropTransPlanting"); }
            /* 29/05/2012 new preconditions API - end */
            
            return result;
        }
        private void SetParametersInputsCurrentValue()
        {
            CropTransplanting.GreenLeafAreaIndexVarInfo.CurrentValue = _GreenLeafAreaIndex;
            CropTransplanting.LatencyAfterTransplantVarInfo.CurrentValue = _LatencyAfterTransplant;
            CropTransplanting.LeavesBiomassVarInfo.CurrentValue = _LeavesBiomass;
            CropTransplanting.RootDepthVarInfo.CurrentValue = _RootDepth;
            CropTransplanting.SpecificLeafAreaVarInfo.CurrentValue = _SpecificLeafArea;
            CropTransplanting.StemsBiomassVarInfo.CurrentValue = _StemsBiomass;
            CropTransplanting.StorageOrgansBiomassVarInfo.CurrentValue = _StorageOrgansBiomass;
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
