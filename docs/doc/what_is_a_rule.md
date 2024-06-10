# What is a rule?

Rules are a formal way to model farmers’ behaviour. A rule based model is characterized by 3 main sections:

1. Inputs: state of the system, and time (e.g. soil plant available water and current date) 
2. Parameters (e.g. soil plant available water threshold to trigger irrigation) 
3. Model which returns a true/false output

Rule parameter values are tested against time and/or the state of the system. The state of the system is known via the dynamic variables made available by the component models of the modeled system. 

It may be desirable to model certain types of management even if the relevant impact on production is not simulated (e.g. weeds, pests, diseases impact on production), so as to allow quantification of the use of inputs such as pesticides and possibly to allow modeling the fate of applied pesticides. Finally, given that almost all rule-and-impacts are specific for a year in the rotation, all rules require as input “RotationYear”. If a perennial is modelled, for example an orchard, RotationYear can be set to 1 (one), hence assuming that a mature plant has the same planned management every year.

Note that this approach allows testing tactical decisions: for instance, a rule may plant a given crop if say, the soil profile is at field capacity within a given window of dates, or act a fallow year if those conditions are not met. 

Each rule is set to be tested in a given RotationYear, hence it is implemented in order to be reset (if needed) when the rotation year of relevance ends.

New rules can be added without re-compiling the AgroManagement components. 
