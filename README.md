## Table of contents
* [General info](#General-info)
* [Technologies](#Technologies)
* [Project architecture](#Architecture)
* [Running the Project](#Run)

## General info
This project is calculating the number of Business days and week days between two provided dates.
This projects exposes three standard RESTfull APIs:
api/WeekdaysBetweenTwoDates
api/BusinessDaysBetweenTwoDatespublicHolidayRules
api/BusinessDaysBetweenTwoDates
Which can be consumed by other API's or be used as a backend service for any UI.
## Technologies
Project was created with:
* Microsoft.aspnetcore.app version: 2.1.1
* microsoft.aspnetcore.mvc.core version: 2.1.1
* Nunit  version: 3.10.1 
* Nunit3testadapter version:3.10.0

## Architecture
This project has been created based on SOLID principal and has been covered by unit test cases.
Also the type of dependency injection that aids scaling and maintenance is construction injection which is supported by default by .Net core.
This Solution has been organized to the following projects:
BusinessDay.Common :
Common and global solution tools and configuration are created in this project including but limited to:
Helper Classes,Enums,Configuration Classes and Extension Classes

BusinessDay.Data:
Data layer items of the solution are created in this project including :
Context,DataModel,Dtos,Entities,Models,
BusinessDay.Services:
This project consists of business logic of the solution containing  BusinessDayCounter class and its interface.
BusinessDay.Tests:
This project provides the test cases that covers all of the API's with different range of sample inputs
BusinessDay.Web:
This project is the home of RESTfull APIs.
## Run
To run this project, Open it in Visual Studio 2017 and compile it.
