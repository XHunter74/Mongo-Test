# MongoTest Project

## Overview
MongoTest is a .NET 8.0 application designed to demonstrate the use of MongoDB as a database. It includes a Unit of Work pattern implementation, repository pattern, and a REST API for managing data.

## Features
- REST API for CRUD operations.
- MongoDB integration using the official MongoDB driver.
- Unit of Work pattern for managing database transactions.
- Repository pattern for data access.
- Configurable settings via `appsettings.json`.

## Project Structure
```
MongoTest/
├── Controllers/          # API controllers
├── Models/               # Data models
│   └── Entities/         # Entity definitions
├── Settings/             # Configuration settings
├── UnitOfWork/           # Unit of Work and Repository implementations
├── appsettings.json      # Application configuration
├── Startup.cs            # Application startup and DI configuration
├── Program.cs            # Entry point of the application
└── MongoTest.http        # HTTP request file for testing API endpoints
```

## Prerequisites
- .NET 8.0 SDK
- MongoDB instance (local or remote)

## Getting Started

### 1. Clone the Repository
```bash
git clone <repository-url>
cd MongoTest
```

### 2. Configure MongoDB Settings
Update the `appsettings.json` or `appsettings.Development.json` file with your MongoDB connection details:
```json
{
  "MongoDb": {
    "ConnectionString": "<your-mongodb-connection-string>",
    "DatabaseName": "<your-database-name>"
  }
}
```

### 3. Build and Run the Application
```bash
dotnet build
dotnet run
```

The application will start and be accessible at `https://localhost:5001` or `http://localhost:5000`.

### 4. Test the API
Use the `MongoTest.http` file to test the API endpoints directly in Visual Studio Code with the REST Client extension.

## Key Components

### Unit of Work
The Unit of Work pattern is implemented in the `UnitOfWork/` folder. It ensures that all database operations are managed in a single transaction.

### Repository Pattern
The repository pattern is implemented in the `MongoRepository` class, providing a clean abstraction for data access.

### API Endpoints
API endpoints are defined in the `Controllers/` folder. For example, `DataController.cs` handles CRUD operations for data entities.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
