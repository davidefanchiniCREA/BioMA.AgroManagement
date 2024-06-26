# RuleDateEx class

Triggers event when a relative date and rotation year is reached.

```csharp
public class RuleDateEx : IRules
```

## Public Members

| name | description |
| --- | --- |
| [RuleDateEx](RuleDateEx/RuleDateEx.md)() | The default constructor. |
| [Description](RuleDateEx/Description.md) { get; } | Trigger an event based on the day of the year of the rotation year. |
| [Domain](RuleDateEx/Domain.md) { get; } |  |
| [DomainClassOfReference](RuleDateEx/DomainClassOfReference.md) { get; } | Domain class of reference |
| [ImpactDependency](RuleDateEx/ImpactDependency.md) { get; } | impact to be coupled to the rule |
| [IsContext](RuleDateEx/IsContext.md) { get; } |  |
| [ModellingOptionsManager](RuleDateEx/ModellingOptionsManager.md) { get; } |  |
| [ModelType](RuleDateEx/ModelType.md) { get; } |  |
| [PreconditionsWriter](RuleDateEx/PreconditionsWriter.md) { get; set; } |  |
| [PublisherData](RuleDateEx/PublisherData.md) { get; } |  |
| [RelativeDate](RuleDateEx/RelativeDate.md) { get; set; } | Relative date to trigger rule |
| [RotationYear](RuleDateEx/RotationYear.md) { get; set; } | Rotation year to be matched |
| [TimeStep](RuleDateEx/TimeStep.md) { get; } |  |
| [URL](RuleDateEx/URL.md) { get; } | Description on the knowledge base. |
| [CheckRule](RuleDateEx/CheckRule.md)(…) | Apply crop management based on relative date and rotation year. |
| [GetStrategyDomainClassesTypes](RuleDateEx/GetStrategyDomainClassesTypes.md)() |  |
| [LoadXml](RuleDateEx/LoadXml.md)(…) | Reads management content from a XmlNode |
| [SaveXml](RuleDateEx/SaveXml.md)(…) | Stores actual data in a passed xml file |
| [TestPreConditions](RuleDateEx/TestPreConditions.md)(…) | Test if rule inputs respect pre-conditions. |
| [TestPreconditionsOnParameters](RuleDateEx/TestPreconditionsOnParameters.md)(…) |  |
| static [Inputs](RuleDateEx/Inputs.md) { get; } | list of inputs |
| static [modelDescription](RuleDateEx/modelDescription.md) { get; } | Model summary description/// |
| static [Outputs](RuleDateEx/Outputs.md) { get; } | list of outputs |
| static [Parameters](RuleDateEx/Parameters.md) { get; } | list of parameters |
| static [RelativeDateVarInfo](RuleDateEx/RelativeDateVarInfo.md) { get; } | VarInfo of relative date to be matched |
| static [RotationYearVarInfo](RuleDateEx/RotationYearVarInfo.md) { get; } | VarInfo of rotation year to be matched |

## See Also

* interface [IRules](../CRA.AgroManagement/IRules.md)
* namespace [CRA.AgroManagement.Rules](../BioMA.AgroManagement.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.AgroManagement.dll -->
