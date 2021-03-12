# Getting Started

### Prerequisite

.NET 5.0
Visual Studio 2019 v16.8 (or better)
SQL Server 2017 (or better)

### appsettings.json

Modify the ConnectionStrings in appsettings.json file
"Default": "Server={YourPCName}\\{YourSQLInstanceName};Database={YourDBName};User Id=sa;Password={Password};"

### Build The Solution

### CarPark.Infrastructure

Open `Package Manager Console`
Select `Default Project` as `src\CarPark.Infrastructure` 
Type `update-database` then hit `Enter`

### CarPark.API

Make sure `CarPark.API` is set as Startup Project
Hit `Ctrl + F5`