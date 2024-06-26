# RuleIrrigatePAWex class

Trigger irrigation within a range of date, for a maximum number of times, if plant available water gets below a given threshold in a soil layer of chosen depth, on a specific rotationYear

```csharp
public class RuleIrrigatePAWex : IRules
```

## Public Members

| name | description |
| --- | --- |
| [RuleIrrigatePAWex](RuleIrrigatePAWex/RuleIrrigatePAWex.md)() | The default constructor. |
| [Description](RuleIrrigatePAWex/Description.md) { get; } | Rule for repeated irrigation based on soil water content. |
| [Domain](RuleIrrigatePAWex/Domain.md) { get; } |  |
| [DomainClassOfReference](RuleIrrigatePAWex/DomainClassOfReference.md) { get; } | Domain class of reference |
| [ExcludeLayerNotFullyWithinReferenceDepth](RuleIrrigatePAWex/ExcludeLayerNotFullyWithinReferenceDepth.md) { get; set; } | Exclude bottom layer for PAW if not fully within RefrenceDepth |
| [ExcludeTopLayer](RuleIrrigatePAWex/ExcludeTopLayer.md) { get; set; } | Exclude top layer for PAW |
| [ImpactDependency](RuleIrrigatePAWex/ImpactDependency.md) { get; } | impact to be coupled to the rule |
| [IsContext](RuleIrrigatePAWex/IsContext.md) { get; } |  |
| [MaxNumberIrrigations](RuleIrrigatePAWex/MaxNumberIrrigations.md) { get; set; } | Maximum number of irrigations |
| [Metadata](RuleIrrigatePAWex/Metadata.md) { get; } |  |
| [ModellingOptionsManager](RuleIrrigatePAWex/ModellingOptionsManager.md) { get; } |  |
| [ModelType](RuleIrrigatePAWex/ModelType.md) { get; } |  |
| [PreconditionsWriter](RuleIrrigatePAWex/PreconditionsWriter.md) { get; set; } |  |
| [PublisherData](RuleIrrigatePAWex/PublisherData.md) { get; } |  |
| [ReferenceDepth](RuleIrrigatePAWex/ReferenceDepth.md) { get; set; } | Reference depth to check for PAW |
| [RelativeDateBegin](RuleIrrigatePAWex/RelativeDateBegin.md) { get; set; } | Relative date to start |
| [RelativeDateEnd](RuleIrrigatePAWex/RelativeDateEnd.md) { get; set; } | Relative date to end |
| [RotationYear](RuleIrrigatePAWex/RotationYear.md) { get; set; } | Rotation year to be matched |
| [ThresholdPAW](RuleIrrigatePAWex/ThresholdPAW.md) { get; set; } | Fraction of plant available water at which irrigation is applied |
| [TimeStep](RuleIrrigatePAWex/TimeStep.md) { get; } |  |
| [URL](RuleIrrigatePAWex/URL.md) { get; } | Description on the knowledge base |
| [CheckRule](RuleIrrigatePAWex/CheckRule.md)(…) | Apply crop management based on: - relative date window - rotation year - max number of irrigations - averaged soil plant available water over a reference depth NOTE: it will include the water content of the last layer included in the reference depth |
| [GetStrategyDomainClassesTypes](RuleIrrigatePAWex/GetStrategyDomainClassesTypes.md)() |  |
| [LoadXml](RuleIrrigatePAWex/LoadXml.md)(…) | Reads management content from a XmlNode |
| [SaveXml](RuleIrrigatePAWex/SaveXml.md)(…) | Stores actual data in a passed xml file |
| [TestPreConditions](RuleIrrigatePAWex/TestPreConditions.md)(…) | Test if rule inputs respect pre-conditions. |
| [TestPreconditionsOnParameters](RuleIrrigatePAWex/TestPreconditionsOnParameters.md)(…) |  |
| static [Inputs](RuleIrrigatePAWex/Inputs.md) { get; } | list of inputs |
| static [MaxNumberIrrigationsVarInfo](RuleIrrigatePAWex/MaxNumberIrrigationsVarInfo.md) { get; } | VarInfo of maximum number of irrigations |
| static [Outputs](RuleIrrigatePAWex/Outputs.md) { get; } | list of outputs |
| static [Parameters](RuleIrrigatePAWex/Parameters.md) { get; } | list of parameters |
| static [ReferenceDepthVarInfo](RuleIrrigatePAWex/ReferenceDepthVarInfo.md) { get; } | VarInfo of reference depth to check for PAW |
| static [RelativeDateBeginVarInfo](RuleIrrigatePAWex/RelativeDateBeginVarInfo.md) { get; } | VarInfo of relative date to be matched |
| static [RelativeDateEndVarInfo](RuleIrrigatePAWex/RelativeDateEndVarInfo.md) { get; } | VarInfo of relative date to be matched |
| static [RotationYearVarInfo](RuleIrrigatePAWex/RotationYearVarInfo.md) { get; } | VarInfo of rotation year to be matched |
| static [ThresholdPAWVarInfo](RuleIrrigatePAWex/ThresholdPAWVarInfo.md) { get; } | VarInfo of fraction of plant available water at which irrigation is applied |

## See Also

* interface [IRules](../CRA.AgroManagement/IRules.md)
* namespace [CRA.AgroManagement.Rules](../BioMA.AgroManagement.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.AgroManagement.dll -->
