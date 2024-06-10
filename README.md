# BioMA.AgroManagement

This package contains the code used for modeling and simulating agricultural management in crop models.

## Usage

Simply refer to this NuGet package in projects.

## License

This package is licensed under the [MIT License](https://licenses.nuget.org/MIT).

## Abstract

The goal of many agricultural modeling studies is to quantify the impact of agricultural management on production and system externalities. Agricultural management must be simulated in such a way either to mimic as closely as possible farmers’ behavior (current conditions) or to explore new environmental conditions (e.g. increase of variability of rainfall patterns). Limiting the drivers of the decision making process to the biophysical system implies that each action must be triggered at run time via a set of rules which can be based on the state of the system, on management decisions which can be related to resources availability, and on the physical characteristics of the system. Furthermore, the implementation of the management simulation must account for a broad range of actions within each of the typologies of management. 

Simulation of complex systems is increasingly being implemented using a modular, component based approach. Implementing the simulation of management in a component based system poses challenges in defining a framework which must be reusable and able to account for a variety of agricultural management technologies applied to different production enterprises. Furthermore, the implementation of management must allow using different approaches to model its impact on different model components. 

AgroManagement is a software component to implement management events in a simulation model. It formalizes the decision making process via models called rules, and it formalizes the drivers of the implementation of the impact on the biophysical system via set of parameters encapsulated in data-types called impacts. The component can be extended without recompilation, both as rules and as impacts. The information on the biophysical system is passed via a data-type called StatesAgroMan; states also can be extended. 

## AgroManagement

* [The Rule-Impact approach](docs/doc/the_rule_impact_approach.md)
* [What is a rule?](docs/doc/what_is_a_rule.md)
* [What are states?](docs/doc/what_are_states.md)
* [What is an impact?](docs/doc/what_is_an_impact.md)

## Design and Use

### Design by contract

* [Test of preconditions](docs/doc/test_of_preconditions.md)
* [The VarInfo type](docs/doc/varinfo_type.md)

### Codedoc

is available [here](https://github.com/davidefanchiniCREA/BioMA.AgroManagement/blob/main/docs/codedoc/BioMA.AgroManagement.md)
