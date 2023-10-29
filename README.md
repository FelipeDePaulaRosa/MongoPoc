# .NET 7 Web API with MongoDB CRUD Operations

This is a simple project that demonstrates how to create a .NET 7 Web API to connect to a MongoDB database and perform CRUD (Create, Read, Update, Delete) operations on the data. In this example, we'll create a basic API for managing a collection of items.

## Prerequisites

Before getting started, make sure you have the following prerequisites installed on your system:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MongoDB](https://www.mongodb.com/try/download/community) installed and running

## Configuration

- **appsettings.json**: This file contains the configuration for the MongoDB connection. You should replace the connection string with your MongoDB instance.

```json
{
  "MongoDBSettings": {
    "ConnectionString": "yourConnectionString",
    "DatabaseName": "yourDatabase",
    "CollectionName": "yourCollection" 
  }
}
```
appsettings.Development.json: This file is used for development-specific settings.

## Running the Application  
1. Clone this repository.
2. Open a terminal and navigate to the mongo-poc directory.
3. Run the following commands to start the API:

```bash
dotnet build
dotnet run
```
The API should be running at https://localhost:5001 or http://localhost:5000.

## Dependencies

This project uses the following NuGet packages:

- `Microsoft.Extensions.Configuration`
- `Microsoft.Extensions.DependencyInjection`
- `MongoDB.Driver`

You can install these packages using the `dotnet add package` command.

```bash
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package MongoDB.Driver
```
