# Team.SurveyApp

## Setup database

1. Create a database named `TeamSurveyApp`.
2. Run the script `DatabaseSchema.sql` which can be found in the root folder (Or under _/Solution Items_ in Visual Studio). That should create the database structure.
3. Set the database connection. It can be done by two means (more info [here](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)):
    a. At Visual Studio: Right click on the **Team.SurveyApp.Api**. Then click on `Manage User Secrets` and paste this code in the opened json file: `{ "ConnectionString": "<the-connection-string>" }`.
    b. From command line at the _./Team.SurveyApp.Api_ folder run this command: `dotnet user-secrets set "ConnectionString" "<the-connection-string>"`.

## Run the Project

It can be run by either clicking on the IIS Express button in Visual Studio or by calling `dotnet run` from the command line at the _./Team.SurveyApp.Api_ folder.

In either case you can navigate to the `/swagger` page in the site to test the API.

## Missing Points

* The Survey Response API is not implemented.
* Logging is not implemented.
* There is no request validation.

## Room for improvement

It could be nice to implement CQRS to reduce the responsibilities on the Controllers and move those to business objects.

There is no API security at all, but that can be added by using .Net built in libraries and a few filters. The preferred mechanism could be JWT.

## Design and architecture

### Project Organization

The solution is divided into three main projects:

* **Team.SurveyApp:** This project contains all the business logic, this DLL has no external library dependencies since its purpose is to be a representation of the business ideas.
* **Team.SurveyApp.Dapper:** Provides the Dapper based implementation of the repositories.
* **Team.SurveyApp.Api:** Exposes the web API and uses the business project and the Dapper implementation to fulfill its tasks.

### Architectural Patterns

The main architectural pattern used was standard MVC.

Also, dependency injection is used to provide the Controllers the objects they need to work.

### Other patterns

The another important pattern used in this project was the Repository Pattern, as described by Domain Driven Design:

The repositories are business artifacts which purpose is to save the Entities state into a persistent storage (SQL through Dapper in this case).

There is a small sample of Value Objects pattern also (see Email struct).

### About the Abstractions folder

The Abstractions folder in the **Team.SurveyApp** project is meant to be a way to explicitly show some otherwise implicit concepts related to the business objects, like, say, they having an Id, or the repository having certain methods.

This can be used to both, give an idea to future developers on what's the idiosyncrasy of certain objects, and to reduce the amount of repetitive code by allowing certain functions to easily know certain aspects of the objects (see the `Team.SurveyApp.Dapper.Extensions.ConnectionExtensions` class).