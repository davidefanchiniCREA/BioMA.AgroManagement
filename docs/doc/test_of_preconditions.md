## Test of preconditions

The AgroManagement component uses Preconditions package (.NET), a component developed to make numeric tests of pre-conditions and post-conditions in clients of different types. This component was developed having as main target software components implementing agro-ecological models. In fact, pre-conditions and post-conditions are not only useful, when tested, to get all the advantages of the design-by-contract approach, but they are also an essential part of model documentation. Furthermore, the clear definition of pre-conditions and post-conditions is of great help during the development of agro-ecological model components; in fact, it allows the programmer to more easily define unit tests by narrowing the ranges of inputs and outputs to be tested.  The component provides some output options for showing/storing tests results (screen, txt file, XML file), but its design also allows clients to easily define custom outputs.

In AgroManagement the test of preconditions is done in two methods (second overloads). The first one is

```
/// <summary>
/// Check rules if test preconditions - states - is positive
/// </summary>
/// <param name="st">states relevant to rules</param>
/// <param name="callID">identifier from caller</param>
/// <returns>object with array of IManagement to be published</returns>
public ActEvents CheckManagement(States st, string callID)
```
In this method preconditions relative to states are tested before testing rules: if the test fails, rules are not tested - management is not applied. This is a test done at run time and could be skipped if other components (which define state values) implement the test of preconditions.

The second method (all overloads, the signature of overload one shown) is:
```
/// <summary>
/// Read management configuration from file or XML fragment
/// </summary>
/// <param name="file">XML file name boolean</param>
/// <param name="xmlObject">XML object</param>
public void InitManagement(string xmlObject, bool file)
```

This test is always made on rules and impacts when the agro-management configuration is loaded. If the test fails, the user is alerted via a message and he/she is prompted to check the log file (PrePostConditionsLog.txt as default file name)