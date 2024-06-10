## The VarInfo type

The VarInfo data-type is used to make available information about each public variable / parameter in AgroManagement. By defining an attribute as a VarInfo type, the attributes description, name, maxValue, minValue, defaultValue, currentValue, units, and varType become available as set / get methods.

The code of the VarInfo class is shown below:

```csharp
using System;
using System.Collections.Generic;
using System.Text;
namespace CRA.Core.Preconditions
{
/// <summary>
/// The class VarInfo contains the specification
/// of information associated to each input/output
/// variable and parameter of a component.
/// </summary>
public class VarInfo : IVarInfo
{
 /// <summary>
 /// Variable type, not used for pre and post conditions tests.
 /// </summary>
 public enum Type
 {
  /// <summary>a state of the system being modelled</summary>
  STATE = 0,
  /// <summary>a rate of the system being modelled</summary>
  RATE = 1,
  /// <summary>a variable which changes during simulation only
  /// due to events</summary>
  PARAMETER = 2,
     /// <summary>a variable which changes at each time step but  
           /// it is neither a state nor a rate</summary>
     AUXILIARY = 3,
  /// <summary>typically an exogenous variable</summary>
  UNDEFINED = 4
 }
 
 private string _description;
 private string _name;
       private string _URL;
 private double _maxValue;
 private double _minValue;
 private double _defaultValue;
 private object _currentValue;
 private string _units;
 private Type localVarType;
 /// <summary>variable description </summary>
 public string Description
 {
  get {return _description; }
  set {_description = value; }
 }
       /// <summary>Variable description URL</summary>
       public string URL
       {
           get { return _URL; }
           set { _URL = value; }
       }
 /// <summary>Variable name </summary>
 public string Name
 {
  get {return _name; }
  set {_name = value; }
 }
 /// <summary>Maximum value allowed</summary>
 public double MaxValue
 {
  get{return _maxValue; }
  set{_maxValue = value; }
 }
 /// <summary>Minimum value allowed</summary>
 public double MinValue
 {
  get{return _minValue; }
  set{_minValue = value; }
 }
 /// <summary>Default value</summary>
 public double DefaultValue
 {
  get{return _defaultValue; }
  set{_defaultValue = value; }
 }
 /// <summary>Value at run time </summary>
 public object CurrentValue
 {
  get{return _currentValue; }
  set{_currentValue = value; }
 }
 /// <summary>Units, not used for pre and post-conditions tests </summary>
 public string Units
 {
  get{return _units; }
  set{_units = value; }
 }
    /// <summary>Variable type (enumerator <c>Type</c>)</summary>
 public Type VarType
 {
  get{return localVarType; }
  set{localVarType = value; }
 }
}
}
```