# BioMA.AgroManagement assembly

## CRA.AgroManagement namespace

| public type | description |
| --- | --- |
| class [ActEvents](./CRA.AgroManagement/ActEvents.md) | Actual events contains the impact objects relevant to the rules met at a given time step. |
| class [AgroManagementSimulationEvent](./CRA.AgroManagement/AgroManagementSimulationEvent.md) |  |
| abstract class [AManagementTypes](./CRA.AgroManagement/AManagementTypes.md) | Management types enumerator |
| abstract class [ASoilLayer](./CRA.AgroManagement/ASoilLayer.md) | Soil layer properties |
| abstract class [AStatesAgroMan](./CRA.AgroManagement/AStatesAgroMan.md) | States of the system to be used to trigger rules. The list of properties can be extended, as rules depend on specific properties. |
| class [DictionaryConverter](./CRA.AgroManagement/DictionaryConverter.md) | This class links a value type variable (such as Irrigationtype) to the corresponding Key-Value map (such as IrrigationMethods) |
| delegate [HandleEventDelegateType](./CRA.AgroManagement/HandleEventDelegateType.md) |  |
| interface [IAgroManagementProvider](./CRA.AgroManagement/IAgroManagementProvider.md) |  |
| interface [IManagement](./CRA.AgroManagement/IManagement.md) | Base interface for impact classes, implemented via management specific interfaces |
| class [ImpactMap](./CRA.AgroManagement/ImpactMap.md) | Class used to store a specif map and read its values from an xml file |
| class [ImpactMapAttribute](./CRA.AgroManagement/ImpactMapAttribute.md) | This Class creates an Attribute by which the user can specify an assembly name, a full class name and the name of the map property |
| interface [IRules](./CRA.AgroManagement/IRules.md) | IRules is the interface that all rules must implement |
| interface [IScheduling](./CRA.AgroManagement/IScheduling.md) | Summary description for IScheduling. |
| class [PhenologicalDates](./CRA.AgroManagement/PhenologicalDates.md) | Data-type with phenological dates |
| class [PhenologicalDatesVarInfo](./CRA.AgroManagement/PhenologicalDatesVarInfo.md) | PhenologicalDatesRainDataVarInfo contains the attributes for each variable in the domain class PhenologicalDates. Attributes are valorized via the static constructor. The data-type VarInfo causes a dependency to the assembly CRA.Core.Preconditions.dll |
| class [Scheduling](./CRA.AgroManagement/Scheduling.md) | Methods to load an agro-managemnt configuration and to test rules at run-time. |
| class [SchEvents](./CRA.AgroManagement/SchEvents.md) | Data-type containing scheduled rules and events |
| class [SoilLayer](./CRA.AgroManagement/SoilLayer.md) | Data-type of soil layer properties used by rules |
| class [SoilLayerVarInfo](./CRA.AgroManagement/SoilLayerVarInfo.md) | SoilLayerRainDataVarInfo contains the attributes for each variable in the domain class SoilLayer. Attributes are valorized via the static constructor. The data-type VarInfo causes a dependency to the assembly CRA.Core.Preconditions.dll |
| class [StatesAgroMan](./CRA.AgroManagement/StatesAgroMan.md) | State values used as inputs for testing agromanagement rules at run-time |
| class [StatesAgroManVarInfo](./CRA.AgroManagement/StatesAgroManVarInfo.md) | StatesRainDataVarInfo contains the attributes for each variable in the domain class StatesAgroMan. Attributes are valorized via the static constructor. The data-type VarInfo causes a dependency to the assembly CRA.Core.Preconditions.dll |
| class [XmlIO](./CRA.AgroManagement/XmlIO.md) | Constants of the AgroManagement component |

## CRA.AgroManagement.Writers namespace

| public type | description |
| --- | --- |
| interface [IWriters](./CRA.AgroManagement.Writers/IWriters.md) | Interface to be implemented by writers of applied management records |
| class [WriteTxt](./CRA.AgroManagement.Writers/WriteTxt.md) | Writer to save impacts published and their values as TXT file |
| class [WriteXml](./CRA.AgroManagement.Writers/WriteXml.md) | Writer to save impacts published and their values as XML file |

## global namespace

| public type | description |
| --- | --- |
| class [AssemblyInfoAM](./global/AssemblyInfoAM.md) | This class uses the System.Reflection.Assembly class to access assembly meta-data. |

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.AgroManagement.dll -->