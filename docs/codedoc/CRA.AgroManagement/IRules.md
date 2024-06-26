# IRules interface

IRules is the interface that all rules must implement

```csharp
public interface IRules : IStrategy, IVarInfoClass
```

## Members

| name | description |
| --- | --- |
| [ImpactDependency](IRules/ImpactDependency.md) { get; } | impact to be coupled to the rule |
| [RotationYear](IRules/RotationYear.md) { get; set; } | the rotation year |
| [CheckRule](IRules/CheckRule.md)(…) | Rule classes must implemnt this interface. A rule may or may not write parameters values |
| [LoadXml](IRules/LoadXml.md)(…) | Reads management content from a XmlNode |
| [SaveXml](IRules/SaveXml.md)(…) | Stores actual data in a passed xml file |
| [TestPreConditions](IRules/TestPreConditions.md)(…) | Test preconditions of parameters internal to the rule It is assumed that states are tested by other components |

## See Also

* namespace [CRA.AgroManagement](../BioMA.AgroManagement.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.AgroManagement.dll -->
