
# Employee Management System

## Description
This employee management system is a web application divided into two parts: a web client built with Blazor Webassembly and a server built with ASP.NET 8.0 web Api. The client provides an interactive and responsive user interface, while the server handles the business logic and communication with the database.

## Characteristics

### Client (Blazor Webassembly)
- Modern and responsive user interface.
- Allows users to view, add, edit and delete employees.
- Viewing statistics for various groups of employees, organized by department, specialty, region and country.

### Server (ASP.NET 8.0 webApi)
- JWT based authentication to ensure application security.
- Implementation of the Repository design pattern to separate the data access and business logic layers.
- Uses Entity Framework Core to connect to the SQL Server database.
- Offers endpoints for employee management and statistics.

## Install
1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Make sure you have an instance of SQL Server configured and update the connection string in the `appsettings.json` file with your database details.
4. Compile and run the project.

## Use
Once the app is up and running, you can access the web client in your browser and create an account, then log in with your credentials. From there, you will be able to manage employees and view statistics related to employee groups.
