using System;
using System.Collections.Generic;
using System.Reflection;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;

namespace CRA.AgroManagement
{
    /// <summary>
    /// States of the system to be used to trigger rules.
    /// The list of properties can be extended, as rules depend
    /// on specific properties. 
    /// </summary>
    public abstract class AStatesAgroMan : IDomainClass
    {
        #region from deleted CurrentTime

        #region ex-CurrentTime Constructors
        public void ConfigureCurrentTime(string date, int rotationYear)
        {
            if (date.IndexOf("-") > 0) { CHR_SEPARATOR = "-"; }
            ParseDate(date);
            _rotationYear = rotationYear;
        }

        /// <summary>
        /// Constructor with no parameters
        /// </summary>
		public void ConfigureCurrentTime()
        {

        }

        #endregion ex-CurrentTime Constructors

        #region Private fields to hold property values
        private string CHR_SEPARATOR = "/";
        private int _rotationYear;
        private int _currentDay;
        private int _currentHour;
        private int _month;
        private int _currentYear;
        private int _day;
        #endregion Private fields to hold property values

        #region properties
        public int CurrentHour
        {
            get
            {
                return _currentHour;
            }
            set
            {
                _currentHour = value;
            }
        }


        /// <summary>
        /// Current day (1 to 365)
        /// </summary>
        public int CurrentDay
        {
            get { return _currentDay; }
            set { _currentDay = value; }
        }

        /// <summary>
        /// Rotation year is year order of a rotation
        /// (e.g. 3 years rotation, rotationYear 1-3;
        /// orchards asuming a costant level of production, rotatioYear=1)
        /// </summary>
        public int RotationYear
        {
            get { return _rotationYear; }
            set { _rotationYear = value; }
        }

        /// <summary>
        /// Simulation year
        /// </summary>
        public int CurrentYear
        {
            get { return _currentYear; }
            set { _currentYear = value; }
        }

        /// <summary>
        /// Simulation month
        /// </summary>
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        /// <summary>
        /// Simulation day
        /// </summary>
        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }
        #endregion properties

        #region Methods
        /// <summary>
        /// from date (dd/mm/yy, dd-mm-yy or yyyy) to day, month, year, DOY
        /// </summary>
        /// <param name="date">date</param>
        /// <returns>day of the year (1-365)</returns>
        private void ParseDate(string date)
        {
            int[] months = { 0, 31, 59, 90, 120, 151, 171, 202, 233, 263, 294, 324 };
            int year;
            string yearString;
            string extraChar = "";

            if (date.IndexOf("-") < 1 && date.IndexOf("/") < 1)
            {
                if (date.Length == 5 || date.Length == 7)
                { date = "0" + date; }
                try
                {
                    _day = int.Parse(date.Substring(0, 2));
                    _month = int.Parse(date.Substring(2, 2));
                    year = int.Parse(date.Substring(4, date.Length - 4));
                }
                catch (Exception err)
                {
                    throw new Exception("The date passed " + date + " has wrong format, either 5,6,7,8 number expected, if no separators are used", err);
                }
            }
            else
            {
                try
                {
                    //find separator characters 2 times
                    int pos = 0;
                    _day = int.Parse(date.Substring(pos, date.IndexOf(CHR_SEPARATOR, pos + 1) - pos));
                    pos = date.IndexOf(CHR_SEPARATOR, pos + 1) + 1;
                    _month = int.Parse(date.Substring(pos, date.IndexOf(CHR_SEPARATOR, pos + 1) - pos));
                    pos = date.IndexOf(CHR_SEPARATOR, pos + 1) + 1;
                    year = int.Parse(date.Substring(pos, date.Length - pos));
                }
                catch (Exception err)
                {
                    throw new Exception("The date passed " + date + " has wrong format, either / or - separators needed; day, month, and year expected", err);
                }
            }
            _currentDay = _day + months[_month - 1];

            if (year < 10) { extraChar = "0"; }
            if (year < 50)
            {
                yearString = "20" + extraChar + year.ToString();
            }
            else if (year > 50 && year < 1000)
            {
                yearString = "19" + extraChar + year.ToString();
            }
            else
            {
                yearString = year.ToString();
            }
            _currentYear = int.Parse(yearString);
        }
        #endregion Methods

        #endregion from deleted CurrentTime


        #region Enumerator
        /// <summary>
        /// Crop/grass/orchard/vineyard phenological states
        /// this list should be extended according to need
        /// Rules may have a specific dependency upon some values
        /// only of the enumerator
        /// </summary>
        public enum PhenologicalStates
        {
            /// <summary>
            /// Fallow
            /// </summary>
            NO_CROP = 0,
            /// <summary>
            /// Crop is planted
            /// </summary>
            PLANTED = 1,
            /// <summary>
            /// Crop has emerged
            /// </summary>
            EMERGED = 2,
            /// <summary>
            /// Juvenile phase ended
            /// </summary>
            JUVENILE_PHASE_ENDED = 3,
            /// <summary>
            /// Photo inductive phase ended
            /// </summary>
            PHOTO_INDUCTIVE_PHASE_ENDED = 4,
            /// <summary>
            /// Tubers initiated
            /// </summary>
            TUBER_ROOT_INITIATED = 5,
            /// <summary>
            /// Crop is flowering
            /// </summary>
            FLOWERING = 6,
            /// <summary>
            /// Grain filling
            /// </summary>
            GRAIN_FILLING = 7,
            /// <summary>
            /// Grain growth ended
            /// </summary>
            PHYSIOLOGICAL_MATURITY_REACHED = 8,
            /// <summary>
            /// Crop/fruits/grapes can be harvested
            /// </summary>
            HARVESTABLE = 9,
            /// <summary>
            /// Tillering 
            /// </summary>
            TILLERING = 10,
            /// <summary>
            /// Wood species dormancy
            /// </summary>
            DORMANCY = 11,
        }
        #endregion

        #region IDomainClass Members

        /// <summary>
        /// Description of the domain class
        /// </summary>
        public string Description
        {
            get { return "States for the AgroManagement component"; }
        }

        /// <summary>
        /// Web reference to the knowledge base
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless-ip.org"; }
        }

        public abstract IList<string> StrategyUsed { get; }

        #endregion

        #region Private fields to hold properties values

        private PhenologicalStates _phenologicalState;
        private List<SoilLayer> _soilLayers = new List<SoilLayer>();
        private PhenologicalDates _phenologicalDates;
        private double _leafAreaIndex;
        private double _aboveGroundBiomass;
        private double _airTemperatureAverage;
        private double _waterLevel;
        private double _sugarContent;
        private double _rain;
        private double _soilTemperatureUpperLayer;
        private double _crownRadius;
        private double _SUCROStypeDVS;
        private double _DevelopmentStageCode;
        private double _growingDegreeDays;
        private double _growingDegreeDaysTransplanting;
        private double _hostTissueDiseased;
        private double _riskLevel;
        private double _infectionEvents;
        private double _waterStress;
        #endregion

        #region Properties
        /// <summary>
        /// Dates at which phenologic events occur
        /// </summary>
        public PhenologicalDates PhenologicalDates
        {
            get { return _phenologicalDates; }
            set { _phenologicalDates = value; }
        }

        /// <summary>
        /// Soil layers variables
        /// </summary>
        public List<SoilLayer> SoilLayers
        {
            get { return _soilLayers; }
            set { _soilLayers = value; }
        }

        /// <summary>
        /// Above ground biomass
        /// </summary>
        public double AboveGroundBiomass
        {
            get { return _aboveGroundBiomass; }
            set { _aboveGroundBiomass = value; }
        }

        /// <summary>
        /// Leaf area index
        /// </summary>
        public double LeafAreaIndex
        {
            get { return _leafAreaIndex; }
            set { _leafAreaIndex = value; }
        }

        /// <summary>
        /// Phenological state of the crop/orchard/vineyard
        /// </summary>
        public PhenologicalStates PhenologicalState
        {
            get { return _phenologicalState; }
            set { _phenologicalState = value; }
        }

        /// <summary>
        /// Average air temperature
        /// </summary>
        public double AirTemperatureAverage
        {
            get { return _airTemperatureAverage; }
            set { _airTemperatureAverage = value; }
        }

        /// <summary>
        /// Water level (rice crop)
        /// </summary>
        public double WaterLevel
        {
            get { return _waterLevel; }
            set { _waterLevel = value; }
        }

        /// <summary>
        /// Sugar content in yield (fruits, berries etc.)
        /// </summary>
        public double SugarContent
        {
            get { return _sugarContent; }
            set { _sugarContent = value; }
        }

        /// <summary>
        /// Daily rainfall
        /// </summary>
        public double Rain
        {
            get { return _rain; }
            set { _rain = value; }
        }


        /// <summary>
        /// DevelopmentStageCode (1 to 4)
        /// </summary>
        public double DevelopmentStageCode
        {
            get { return _DevelopmentStageCode; }
            set { _DevelopmentStageCode = value; }
        }


        /// <summary>
        /// SUCROStypeDVS (1 to 2)
        /// </summary>
        public double SUCROStypeDVS
        {
            get { return _SUCROStypeDVS; }
            set { _SUCROStypeDVS = value; }
        }

        /// <summary>
        /// Soil temperature of the upper layer
        /// </summary>
        public double SoilTemperatureUpperLayer
        {
            get { return _soilTemperatureUpperLayer; }
            set { _soilTemperatureUpperLayer = value; }
        }

        /// <summary>
        /// Plant crown radius
        /// </summary>
        public double CrownRadius
        {
            get { return _crownRadius; }
            set { _crownRadius = value; }
        }


        /// <summary>
        /// Plant growing degree days
        /// </summary>
        public double GrowingDegreeDays
        {
            get { return _growingDegreeDays; }
            set { _growingDegreeDays = value; }
        }

     
        /// <summary>
        /// Plant growing degree days
        /// </summary>
        public double GrowingDegreeDaysTransplanting
        {
            get { return _growingDegreeDaysTransplanting; }
            set { _growingDegreeDaysTransplanting = value; }
        }

     
        /// <summary>
        /// Host tissue diseased
        /// </summary>
        public double HostTissueDiseased
        {
            get { return _hostTissueDiseased; }
            set { _hostTissueDiseased = value; }
        }

        
        /// <summary>
        /// Disease risk level
        /// </summary>
        public double RiskLevel
        {
            get { return _riskLevel; }
            set { _riskLevel = value; }
        }

    
        /// <summary>
        /// Number of infection events
        /// </summary>
        public double InfectionEvents
        {
            get { return _infectionEvents; }
            set { _infectionEvents = value; }
        }

       
        /// <summary>
        /// water stress
        /// </summary>
        public double WaterStress
        {
            get { return _waterStress; }
            set { _waterStress = value; }
        }

        #endregion


        public AStatesAgroMan()
        {
            _io = new ParametersIO(this);
        }

        #region Implementation of IDomainClass

        private readonly ParametersIO _io;
        public bool ClearValues()
        {
            _phenologicalState = new PhenologicalStates();
            _soilLayers = new List<SoilLayer>();
            _phenologicalDates = new PhenologicalDates();
            _leafAreaIndex = 0;
            _aboveGroundBiomass = 0;
            _airTemperatureAverage = 0;
            _waterLevel = 0;
            _sugarContent = 0;
            _rain = 0;
            _soilTemperatureUpperLayer = 0;
            _crownRadius = 0;
            _DevelopmentStageCode = 0;
            _SUCROStypeDVS = 0;
            _growingDegreeDays = 0;
            _growingDegreeDaysTransplanting = 0;
            _hostTissueDiseased = 0;
            _riskLevel = 0;
            _infectionEvents = 0;
            _waterStress = 0;
            return true;
        }

        public IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {

                return _io.GetCachedProperties(typeof(IDomainClass));
            }
        }

        #endregion
    }
}
