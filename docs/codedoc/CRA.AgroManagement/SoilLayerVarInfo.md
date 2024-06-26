# SoilLayerVarInfo class

SoilLayerRainDataVarInfo contains the attributes for each variable in the domain class SoilLayer. Attributes are valorized via the static constructor. The data-type VarInfo causes a dependency to the assembly CRA.Core.Preconditions.dll

```csharp
public class SoilLayerVarInfo : IVarInfoClass
```

## Public Members

| name | description |
| --- | --- |
| [SoilLayerVarInfo](SoilLayerVarInfo/SoilLayerVarInfo.md)() | The default constructor. |
| [Description](SoilLayerVarInfo/Description.md) { get; } | Soil layer attributes used in the component AgroManagement |
| [DomainClassOfReference](SoilLayerVarInfo/DomainClassOfReference.md) { get; } | Domain class of reference |
| [URL](SoilLayerVarInfo/URL.md) { get; } | Description of the domain class on the knowledge base |
| static [BulkDensity](SoilLayerVarInfo/BulkDensity.md) { get; } | soil bulk density |
| static [FieldCapacityVolSWC](SoilLayerVarInfo/FieldCapacityVolSWC.md) { get; } | volumetric soil water content at field capacity |
| static [LayerThickness](SoilLayerVarInfo/LayerThickness.md) { get; } | soil layer thickness |
| static [SoilWaterContentVol](SoilLayerVarInfo/SoilWaterContentVol.md) { get; } | volumetric soil water content |
| static [SoilWaterPotential](SoilLayerVarInfo/SoilWaterPotential.md) { get; } | soil water retention tension |
| static [WiltPointVolSWC](SoilLayerVarInfo/WiltPointVolSWC.md) { get; } | volumetric soil water content at permanent wilting point |

## See Also

* namespace [CRA.AgroManagement](../BioMA.AgroManagement.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.AgroManagement.dll -->
