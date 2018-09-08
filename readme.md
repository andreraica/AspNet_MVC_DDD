# Projeto AspNet_MVC_DDD

Simple AngularJS interface using WebAPI, MVC and Identity to financial control

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Framework 4.5] - Microsoft .NET Framework 4.5
* [SQLExpress] - Microsoft SQL Express

### Run Steps

#### >>> Visual Studio Solution
**Openning**
1) Open solution file [ControleFinanceiro.sln] in your Visual Studio
2) Set the project [0-Presentation/Budget.Presentation.MVC] as StartUp Project

**Database - Executing Entity Framework CodeFirst**
3) Open Package Manager Console on Visual Studio
4) Select default project [4-Infrastructure\Budget.Infrastructure.Data]
5) Execute the command:
```sh
update-database -verbose -StartUpProjectName Budget.Services.WebAPI
````
6) Select default project [4-Infrastructure\4.1-CrossCutting\Budget.Infrastructure.CrossCutting.Identity]
7) Execute the command:
```sh
update-database -verbose -StartUpProjectName Budget.Services.WebAPI
````

**Running**
8) Press play button (This action should restore the Nuget Packages)


### How to use
**After execute the Run Steps**
1) Open your browser - [localhost:1099/Home] (MVC-Razor Interface) OR [localhost:1099/Angular] (AngularJS Interface)
2) Create your simple account localy
2) Input youy account at login
3) Navigate beteween menu and enjoy :)

# About Project!

### Data API

> Every data are using 'SQLExpress' localy making this project simpler.

### Basic Tech

**This project is using SOLID concepts**

* User Input: AngularJS and MVC Application
* Project Tiers: Class Library
* Authentication: OAuth / Owin Identity
* Concerns DDD and TDD (Mocks e Stubs)
* MVC 5 
* AngularJS
* AutoMapper
* Entity Framework - CodeFirst / Migrations - Dapper

**Tiers:**
>Domain 
* Model & Services: Domain is a global tier used by all tiers providing the main entities and services

>Application
* this layer orchestrate the services invokes between API and Service

>Infrastructure
* Data: This tier consumes the WebAPI. It has your own model to manipulate the JSON and response to Services 
* IoC: This tier just Inject all dependencies (DI) - using package SimpleInjector

### Next Steps Todo

 - Refactor code
 - Full translate to English

License
----

**Free by Andre Raiça Silva**