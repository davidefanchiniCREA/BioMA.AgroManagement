## The Rule-Impact Approach

An agricultural production activity comprises one or more production enterprises (e.g. a crop, a rotation, an orchard), each managed using a production technique. A production technique is a set of planned actions. 

Actions are planned using a rotation template, in which from one to several years are considered. Such years are defined as "RotationYears". For instance, a mono-crop will have 1 rotation year, hence the value of the variable RotationYear will always be 1; all rules defined assigning RotationYear = 1 will be tested at each year of the simulation. A two-year rotation, say maize-wheat, will have 2 rotation years, hence the value of the variable RotationYear will be either 1 or 2 according to what crop of the rotation is targeted with the planned agro-management action. 

An action, to be applied, requires that a set of conditions (a "rule") is met. When the requirements of a rule are satisfied, a management action is implemented. In modelling terms, implementing a management action requires two steps during simulation: 

1. A set of parameters ("impact") is made available to a model (component); 
2. The model component makes use of the parameters provided to implement the impact.

AgroManagement checks a set of rules at each time-step, and makes available an instance of the associated impact to the simulation system if the rule results true. The data-type needed to provide the component a configuration to be tested at run time is then (graphical representation of the XML schema)

This approach allows specifying any biophysical driver of the decisional process to apply management for any management, it allows specifying any agro-technical input, and it allows using any impact model to implement the impact of the action. Furthermore, it allows formalizing in a transparent and extensible way all the concepts relevant to agro-management, providing instances for a domain specific ontology. Finally, its independent implementation allows de-coupling agro-management from biophysical models, thus adhering to the component-oriented design paradigm of simulation models.  