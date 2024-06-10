# What are states?

Rule parameter values are tested against time and/or states. States are a subset of the variables made available by a model framework at run-time. Variables into states are the ones relevant for testing rules, and the subset can be extended  according to needs when a new rule is implemented, provided that the needed variables are simulated by the models components used (e.g.components "Crops", "SoilWater", "SoilNitrogen", "Diseases"). In fact, possible states to be used in building rules are the ones made available by model components. 

The following are the state/auxiliary variables needed by currently implemented rules. They are defined in the AgroManagement component; when the AgroManagent component is used in a modelling framework, they must be linked at run-time to states which are outputs of components.

The following list (which in the current release might be extended) is meant to be extended at need (rules which require other state/auxiliary variables) by inheriting from the class StatesAgroman, and by creating a correspondent VarInfo class.

```
PhenologicalStates PhenologicalState;
List<SoilLayer> SoilLayers = new List<SoilLayer>();
PhenologicalDates PhenologicalDates; 
double LeafAreaIndex;
double AboveGroundBiomass;
double AirTemperatureAverage;
double WaterLevel;
double SugarContent;
double Rain;
double SoilTemperatureUpperLayer;
```

The type PhenologicalDates holds variables to be linked to variables set at run-time by components. Each component will in most cases use a subset. 

```
int DatePlanting;
int DateEmergence;
int DateFiveLeaves;
int DateEndJuvanilePhase;
int DateHeading;
int DateBeginTillering;
int DateTuberRootInitiation;
int DateEndPhotoInductivePhase;
int DateBeginStemElongation;
int DateBeginFlowering;
int DateBeginGrainFilling;
int DateMilkDough;
int DateSoftDough;
int DatePhysiologicalMaturity;
```

The type SoilLayer holds variables to be linked to variables set at run-time by, say, a  SoilWater component. 

```
double BulkDensity;
double LayerThickness;
double FieldCapacityVolSWC;
double WiltPointVolSWC;
double SoilWaterContentVol;
double SoilWaterPotential;
```
The enumerator PhenologicalStates has the following enumerators:

```
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

```	