using System;
using System.Xml;
using System.Collections.Generic;

using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using CRA.AgroManagement;

namespace CRA.AgroManagement.Rules
{
	/// <summary>
	/// Trigger irrigation within a range of date, for a maximum number of times,
	/// if plant available water gets below a given threshold in a 
	/// soil layer of chosen depth, on a specific rotationYear
	/// </summary>
	public class RuleIrrigatePAWex : IRules
    {
        public string TestPreconditionsOnParameters(string callID) {
            return "";
        }

        private ITestsOutput _preconditionsWriter;

		public ITestsOutput PreconditionsWriter
        {
			get
            {
				return _preconditionsWriter;
            }

			set
            {
				_preconditionsWriter = value;
				foreach (IStrategy strategy in this.GetAllPossibleAssociatedStrategies())
                {
					strategy.PreconditionsWriter = _preconditionsWriter;
                }
            }
        }

        //local variables
		private int _counter = 0; //Rule is stateful for this field
        private double _totalDepthComputed = 0; //Rule is stateful for this field

        #region Constructor
        /// <summary>
		/// Constructor
		/// </summary>
		static RuleIrrigatePAWex()
		{
			FillInOutParLists();
			SetParameterDescription();
        }
        public RuleIrrigatePAWex()
        {
            ModellingOptions mo = new ModellingOptions(new List<VarInfo> { _maxNumberIrrigationsVarInfo,_referenceDepthVarInfo,_thresholdPAWVarInfo, _relativeDateBeginVarInfo, _relativeDateEndVarInfo, _rotationYearVarInfo },
         new List<PropertyDescription>(), new List<PropertyDescription>(), new List<string>());
            _modellingOptionsManager = new ModellingOptionsManager(mo);
        }

	    #endregion

        #region Lists: Inputs, Parameters, Associated strategies

        private static List<string> _inputs = new List<string>();
		private static List<string> _parameters = new List<string>();
		private static List<string> _outputs = new List<string>();

		/// <summary>list of inputs</summary>
		public static List<string> Inputs 
		{
			get {return _inputs;}
		}
		/// <summary>list of parameters</summary>
		public static List<string> Parameters
		{
			get {return _parameters;}
		}
		/// <summary>list of outputs</summary>
		public static List<string> Outputs
		{
			get {return _outputs;}
		}		
	    #endregion

		#region Parameters
		private int _relativeDateBegin = 1;
		private int _relativeDateEnd = 365;
		private int _rotationYear = 1;
		private int _maxNumberIrrigations;
        private double _thresholdPAW;
        private double _referenceDepth;
	    private bool _excludeTopLayer;
	    private bool _excludeLayerNotFullyWithinReferenceDepth;

        private static VarInfo _relativeDateBeginVarInfo = new VarInfo();
        private static VarInfo _relativeDateEndVarInfo = new VarInfo();
        private static VarInfo _maxNumberIrrigationsVarInfo =  new VarInfo();
        private static VarInfo _rotationYearVarInfo = new VarInfo();
        private static VarInfo _thresholdPAWVarInfo =  new VarInfo();
        private static VarInfo _referenceDepthVarInfo =  new VarInfo();

        //
		//values
		//
		/// <summary>
		/// Relative date to start
		/// </summary>
		public int RelativeDateBegin
		{
			get {return _relativeDateBegin; }
			set {_relativeDateBegin = value; }
		}
		/// <summary>
		/// Relative date to end
		/// </summary>
		public int RelativeDateEnd
		{
			get {return _relativeDateEnd; }
			set {_relativeDateEnd = value; }
		}
		/// <summary>
		/// Rotation year to be matched
		/// </summary>
		public int RotationYear
		{
			get {return _rotationYear; }
			set {_rotationYear = value; }
		}       
		/// <summary>
		/// Maximum number of irrigations
		/// </summary>
		public int MaxNumberIrrigations 
		{
			get {return _maxNumberIrrigations; }
			set {_maxNumberIrrigations = value; }
		}
		/// <summary>
		/// Fraction of plant available water at which irrigation is applied
		/// </summary>
		public double ThresholdPAW 
		{
			get {return _thresholdPAW; }
			set {_thresholdPAW = value; }
		}
		/// <summary>
		/// Reference depth to check for PAW
		/// </summary>
		public double ReferenceDepth 
		{
			get {return _referenceDepth; }
			set {_referenceDepth = value; }
		}
        /// <summary>
        /// Exclude top layer for PAW
        /// </summary>
        public bool ExcludeTopLayer
        {
            get { return _excludeTopLayer; }
            set { _excludeTopLayer = value; }
        }
        /// <summary>
        /// Exclude bottom layer for PAW if not fully within RefrenceDepth
        /// </summary>
        public bool ExcludeLayerNotFullyWithinReferenceDepth
        {
            get { return _excludeLayerNotFullyWithinReferenceDepth; }
            set { _excludeLayerNotFullyWithinReferenceDepth = value; }
        }

		//
		//description
		//
		/// <summary>
		/// VarInfo of relative date to be matched
		/// </summary>
		public static VarInfo RelativeDateBeginVarInfo
		{
			get {return _relativeDateBeginVarInfo; }
		}
		/// <summary>
		/// VarInfo of relative date to be matched
		/// </summary>
		public static VarInfo RelativeDateEndVarInfo
		{
			get {return _relativeDateEndVarInfo; }
		}
		/// <summary>
		/// VarInfo of rotation year to be matched
		/// </summary>
		public static VarInfo RotationYearVarInfo
		{
			get {return _rotationYearVarInfo; }
		}
		/// <summary>
		/// VarInfo of maximum number of irrigations
		/// </summary>
		public static VarInfo MaxNumberIrrigationsVarInfo
		{
			get {return _maxNumberIrrigationsVarInfo; }
		}
		/// <summary>
		/// VarInfo of fraction of plant available water at which irrigation is applied
		/// </summary>
		public static VarInfo ThresholdPAWVarInfo
		{
			get {return _thresholdPAWVarInfo; }
		}
		/// <summary>
		/// VarInfo of reference depth to check for PAW
		/// </summary>
		public static VarInfo ReferenceDepthVarInfo
		{
			get {return _referenceDepthVarInfo; }
		}
		#endregion

        #region IStrategy Members

        /// <summary>
        /// Rule for repeated irrigation based on soil water content.
        /// </summary>
        public string Description
        {
            get { return "Rule for repeated irrigation based on soil water content."; }
        }

        /// <summary>
        /// Description on the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://www.apesimulator.org/ontologybrowser.aspx"; }
        }

	    public XmlElement Metadata
	    {
	        get { throw new NotImplementedException(); }
	    }

	    #endregion

        #region IVarInfoClass Members

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "StatesAgroMan"; }
        }

        #endregion

		#region IRules members
		/// <summary>
		/// impact to be coupled to the rule
		/// </summary>
		public string ImpactDependency
		{
			get { return ""; }
		}
		
		/// <summary>
		/// Apply crop management based on:
		/// - relative date window
		/// - rotation year
		/// - max number of irrigations
		/// - averaged soil plant available water over a reference depth
		/// NOTE: it will include the water content of the last layer included in
		/// the reference depth
		/// </summary>
		/// <param name="st">biophysical states of the system</param>
		/// <param name="m">management parameters</param>
		/// <returns>true is rules are matched</returns>
		public bool CheckRule(StatesAgroMan st, IManagement m)
		{
            bool testRule = false;

			if  (st.CurrentDay >= _relativeDateBegin &
				st.CurrentDay <= _relativeDateEnd &
				_rotationYear == st.RotationYear)
			{
                /* 
                 * Compute effective depth only once
                 *  1) First layer can be excluded
                 *  2) May include or not a layer which is shallower
                 *     than _referenceDepth, but which has bottom depth
                 *    deeper than _referenceDepth
                 * Computing _averagePAW accounts for such choices 
                 */
                if (_totalDepthComputed == 0)
                {
                    bool _topLayerExcluded = false;
                    double _absoluteDepth = 0;
                    foreach (SoilLayer s in st.SoilLayers)
                    {
                        if (_excludeLayerNotFullyWithinReferenceDepth)
                        {
                            if ((_absoluteDepth  + s.LayerThickness) <= _referenceDepth)
                            {
                                _totalDepthComputed += s.LayerThickness;
                                _absoluteDepth += s.LayerThickness;
                            }
                        }
                        else
                        {
                            if (_absoluteDepth < _referenceDepth)
                            {
                                _totalDepthComputed += s.LayerThickness;
                                _absoluteDepth += s.LayerThickness;

                            }
                        }
                        //reset depth if toplayer must be excluded
                        if (_excludeTopLayer)
                        {
                            if (!_topLayerExcluded)
                            {
                                _totalDepthComputed = 0;
                                _topLayerExcluded = true;
                            }
                        }
                    }
                }
                
                //apply management 
				if (_counter < _maxNumberIrrigations)
				{
					double _averagedPAW = 0;
					double _depth = 0;

                    bool _topLayerExcluded = false;
                    foreach (SoilLayer s in st.SoilLayers)
					{
                        _depth += s.LayerThickness;

                        if (_depth <= _totalDepthComputed) //_referenceDepth)
						{
					        double _PAW = s.FieldCapacityVolSWC - s.WiltPointVolSWC;
						    double _SWCFC = s.FieldCapacityVolSWC;
							if (s.SoilWaterContentVol > s.FieldCapacityVolSWC) 
							{
								s.SoilWaterContentVol = _SWCFC;
							}
						    _averagedPAW += ((s.SoilWaterContentVol - s.WiltPointVolSWC)/
						                     _PAW)*
						                    (s.LayerThickness/_totalDepthComputed); //_referenceDepth);
						}
                        //reset PAW and depth if toplayer must be excluded
                        if (_excludeTopLayer)
                        {
                            if (!_topLayerExcluded)
                            {
                                _averagedPAW = 0;
                                _depth = 0;
                                _topLayerExcluded = true;
                            }
                        }

					}
 
                    if (_averagedPAW < _thresholdPAW)
					{
						_counter++;
						testRule = true;
					}
				}
				if (st.CurrentDay == _relativeDateEnd)
				{
					_counter = 0; //resets for next use of same rule
				    _totalDepthComputed = 0; //reset for next use
				}
			}
			return testRule;        
		}

		/// <summary>
        /// Test if rule inputs respect pre-conditions.
		/// </summary>
		/// <param name="m">management parameters</param>
		/// <param name="callID">ID from caller</param>
		public string TestPreConditions(IManagement m, string callID)
		{
            string result;
            //test preconditions of this rule
            result = VerifyPreconditions(callID);
            result += m.TestPreconditions(callID);
            return result;
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
					case ("RelativeDateBegin"):
						_relativeDateBegin = int.Parse(child.Attributes["value"].InnerText);
						break;
					case ("RelativeDateEnd"):
						_relativeDateEnd = int.Parse(child.Attributes["value"].InnerText);
						break;
					case ("RotationYear"):
						_rotationYear = int.Parse(child.Attributes["value"].InnerText);
						break;
					case ("MaxNumberIrrigations"):
						_maxNumberIrrigations = int.Parse(child.Attributes["value"].InnerText);
						break;
					case ("ThresholdPAW"):
						_thresholdPAW = double.Parse(child.Attributes["value"].InnerText);
						break;
					case ("ReferenceDepth"):
						_referenceDepth = double.Parse(child.Attributes["value"].InnerText);
						break;
                    case ("ExcludeTopLayer"):
                        _excludeTopLayer = bool.Parse(child.Attributes["value"].InnerText);
                        break;
                    case ("ExcludeLayerNotFullyWithinReferenceDepth"):
                        _excludeLayerNotFullyWithinReferenceDepth = bool.Parse(child.Attributes["value"].InnerText);
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
			writer.WriteAttributeString("name","RelativeDateBegin");
			writer.WriteAttributeString("value", _relativeDateBegin.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","RelativeDateEnd");
			writer.WriteAttributeString("value", _relativeDateEnd.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","RotationYear");
			writer.WriteAttributeString("value", _rotationYear.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","MaxNumberIrrigations");
			writer.WriteAttributeString("value", _maxNumberIrrigations.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","ThresholdPAW");
			writer.WriteAttributeString("value", _thresholdPAW.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("parameter");
			writer.WriteAttributeString("name","ReferenceDepth");
			writer.WriteAttributeString("value", _referenceDepth.ToString());
			writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "ExcludeTopLayer");
            writer.WriteAttributeString("value", _excludeTopLayer.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", "ExcludeLayerNotFullyWithinReferenceDepth");
            writer.WriteAttributeString("value", _excludeLayerNotFullyWithinReferenceDepth.ToString());
            writer.WriteEndElement();
		}
		#endregion

		#endregion
	    
		#region Preconditions
		private string VerifyPreconditions(string callID)
		{
			SetParametersInputsCurrentValue();
            /* 29/05/2012 old preconditions API - begin */
            //CRA.Core.Preconditions.PreconditionsData prc = new CRA.Core.Preconditions.PreconditionsData();
            //CRA.Core.Preconditions.Preconditions pre = new CRA.Core.Preconditions.Preconditions();
            ////add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(_relativeDateBeginVarInfo);
            //prc.RangeBased.Add(_relativeDateEndVarInfo);
            //prc.RangeBased.Add(_rotationYearVarInfo);
            //prc.RangeBased.Add(_maxNumberIrrigationsVarInfo);
            //prc.RangeBased.Add(_thresholdPAWVarInfo);
            //prc.RangeBased.Add(_referenceDepthVarInfo);
            ////get the evaluation of preconditions
            //string result = pre.VerifyPreconditions(prc, callID);
            //if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Rules.dll, class RuleIrrigatePAW"); }

            /* 29/05/2012 old preconditions API - end */

            /* 29/05/2012 new preconditions API - begin */
            ConditionsCollection prc = new ConditionsCollection();

            Preconditions pre = new Preconditions();
            //add range based (current value must be in the range minValue-maxValue)
            prc.AddCondition(new RangeBasedCondition(_relativeDateBeginVarInfo));
            prc.AddCondition(new RangeBasedCondition(_relativeDateEndVarInfo));
            prc.AddCondition(new RangeBasedCondition(_rotationYearVarInfo));
            prc.AddCondition(new RangeBasedCondition(_maxNumberIrrigationsVarInfo));
            prc.AddCondition(new RangeBasedCondition(_thresholdPAWVarInfo));
            prc.AddCondition(new RangeBasedCondition(_referenceDepthVarInfo));
            //get the evaluation of preconditions
            string result = pre.VerifyPreconditions(prc, callID);
            if (result != "") { pre.TestsOut(PreconditionsWriter, result, true, "Component CRA.AgroManagement.Rules.dll, class RuleIrrigatePAW"); }

            /* 29/05/2012 new preconditions API - end */
            return result;
        }
		private void SetParametersInputsCurrentValue()
		{
			_relativeDateBeginVarInfo.CurrentValue = _relativeDateBegin;
			_relativeDateEndVarInfo.CurrentValue = _relativeDateEnd;
			_rotationYearVarInfo.CurrentValue = _rotationYear;
			_maxNumberIrrigationsVarInfo.CurrentValue = _maxNumberIrrigations;
			_thresholdPAWVarInfo.CurrentValue = _thresholdPAW;
			_referenceDepthVarInfo.CurrentValue = _referenceDepth;
		}
		#endregion
		
		#region  Constructor
		private static void SetParameterDescription()
		{
			_relativeDateBeginVarInfo.Description = "First allowed day of the year to apply management";
			_relativeDateBeginVarInfo.Name = "RelativeDateBegin";
			_relativeDateBeginVarInfo.MaxValue = 366;
			_relativeDateBeginVarInfo.MinValue = 1;
			_relativeDateBeginVarInfo.DefaultValue = 180;
			_relativeDateBeginVarInfo.VarType = VarInfo.Type.PARAMETER;
			_relativeDateBeginVarInfo.Units = "d";
		    _relativeDateBeginVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

			_relativeDateEndVarInfo.Description = "Last allowed day of the year to apply management";
			_relativeDateEndVarInfo.Name = "RelativeDateEnd";
			_relativeDateEndVarInfo.MaxValue = 366;
			_relativeDateEndVarInfo.MinValue = 1;
			_relativeDateEndVarInfo.DefaultValue = 180;
			_relativeDateEndVarInfo.VarType = VarInfo.Type.PARAMETER;
			_relativeDateEndVarInfo.Units = "d";
            _relativeDateEndVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

			_rotationYearVarInfo.Description = "Rotation year when management must be applied";
			_rotationYearVarInfo.Name = "RotationYear";
			_rotationYearVarInfo.MaxValue = 10;
			_rotationYearVarInfo.MinValue = 1;
			_rotationYearVarInfo.DefaultValue = 1;
			_rotationYearVarInfo.VarType = VarInfo.Type.PARAMETER;
			_rotationYearVarInfo.Units = "unitless";
            _rotationYearVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

			_maxNumberIrrigationsVarInfo.Description = "Max number of appliable events";
			_maxNumberIrrigationsVarInfo.Name = "MaxNumberIrrigations";
			_maxNumberIrrigationsVarInfo.MaxValue = 150;
			_maxNumberIrrigationsVarInfo.MinValue = 1;
			_maxNumberIrrigationsVarInfo.DefaultValue = 3;
			_maxNumberIrrigationsVarInfo.VarType = VarInfo.Type.PARAMETER;
			_maxNumberIrrigationsVarInfo.Units = "d";
            _maxNumberIrrigationsVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

			_thresholdPAWVarInfo.Description  = "Fraction of plant available water at which irrigation is applied";
			_thresholdPAWVarInfo.Name = "ThresholdPAW";
			_thresholdPAWVarInfo.MaxValue = 0.8;
			_thresholdPAWVarInfo.MinValue = 0;
			_thresholdPAWVarInfo.DefaultValue = 0.2;
			_thresholdPAWVarInfo.VarType = VarInfo.Type.PARAMETER;
			_thresholdPAWVarInfo.Units = "unitless";
            _thresholdPAWVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

			_referenceDepthVarInfo.Description = "Reference depth to check for PAW";
			_referenceDepthVarInfo.Name = "ReferenceDepth";
			_referenceDepthVarInfo.MaxValue = 3;
			_referenceDepthVarInfo.MinValue = 0.2;
			_referenceDepthVarInfo.DefaultValue = 0.8;
			_referenceDepthVarInfo.VarType = VarInfo.Type.PARAMETER;
			_referenceDepthVarInfo.Units = "m";
            _referenceDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
		}

		private static void FillInOutParLists()
		{
			//inputs
			_inputs.Add("CurrentDay");
			_inputs.Add("RotationYear");
			_inputs.Add("BulkDensity");
			_inputs.Add("LayerThickness");
			_inputs.Add("FieldCapacityVolSWC");
			_inputs.Add("WiltPointVolSWC");
			_inputs.Add("SoilWaterContentVol");
			
			//parameters
			_parameters.Add("RelativeDateBegin");
			_parameters.Add("RelativeDateEnd");
			_parameters.Add("RotationYear");
			_parameters.Add("MaxNumberIrrigations");
			_parameters.Add("ThresholdPAW");
			_parameters.Add("ReferenceDepth");
            _parameters.Add("ExcludeTopLayer");
            _parameters.Add("ExcludeLayerNotFullyWithinReferenceDepth");

			//outputs
			_outputs.Add("true/false");


		}
		#endregion


        #region Implementation of IStrategy

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>();
        }

        public bool IsContext
        {
            get { return false; }
        }

        public IList<int> TimeStep
        {
            get { return new List<int>(); }
        }
        public string ModelType
        {
            get { return "AgromanagementRule"; }
        }

        public string Domain
        {
            get { return "Agromanagement"; }
        }

        public CRA.ModelLayer.MetadataTypes.PublisherData PublisherData
        {
            get { throw new NotImplementedException(); }
        }

        private ModellingOptionsManager _modellingOptionsManager;

        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; }
        }

        #endregion
    }
}
