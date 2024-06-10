## What is an impact?

Impacts is short for: "sets of parameters to implement the impact of a management event in a model component". Such sets are different changing management event, and can be different within management event if the modelling approach to implement the impact is based on alternate approaches.

Impacts can contain actual values of parameters, and or they can contain an alphanumeric field which can simplify the building of the agro-management configuration file. The value of such field are then interpreted by model components which associate to the alphanumeric value all fields corresponding. As an example of the former, an impact for tillage may include two parameters:

```
double TillageDepth
double SoilMixingCoefficient
```

An example of using an alphanumeric field again for tillage can be:

```
double TillageDepth
string ImplementType
```

Where the levels of ImplementType are stored in a list which in this case contain:

```
PLOW_MOLDBOARD_0_2_M,
MULCH_TREADER,
PARATILL_OR_PARAPLOW,
PLANTER_DOUBLE_DISK_OPENERS,
....
```

The items above are extracted from the list of implements of the models Wepp and (Alberts et al., 1995). In the relevant database (managed by the model component which implements the impact of the event), A list of 8 parameters is associated to each of the items in the list, and it allows a model component to implement the impact according to the Wepp's approach. In particular, TillageDepth is one of the parameters encapsulated in the of ImplementType, but providing it separately makes possible to override the value, allowing for more flexibility in setting the planned management event. Using summary alphanumeric fields requires, on the other hand, that model components access directly a dedicated data base to retrieve the parameter values associated to the enumerator value. 

Alphanumeric fields, that we can also call enumerators, are extensible given that they are stored in external XML files. Each enumerator value, to  have a use by a simulation model, as explained above must have a corresponding set of parameters. Such values can be specified using an application called Model Parameter Editor (MPE), which allows storing such sets of parameters for each enumerator in XML files. Such files are used as a data base by model components to retrieve parameter values. New enumerators specified in parameter files then extend options into AgroManagement impacts. Some of such files are provided in the SDK. MPE can then be used to edit existing files, whereas the application Domain Class Coder (DCC) can be used to build new definitions, in case a new impact is being built.
