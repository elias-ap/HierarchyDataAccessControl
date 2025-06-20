# Hierarchy Data Access Control

This backend project, developed in just 2 days, is a hierarchical access control system built with **.NET 8** and **Entity Framework Core**. It facilitates the management of user and group permissions across different levels of a node hierarchy, making it ideal for organizations or systems requiring fine-grained access control.

## Features

- **Hierarchical Data Access Control**: Permissions are used to filter data both in the database and in LINQ operations.
- **User and Group Management**: Manage users and groups efficiently with hierarchical permissions.

## Structure

The solution is organized into separate projects for improved modularity and scalability:

- **Models**: Contains the domain models.
- **Data Access**: Handles the database context and operations.
- **Tests**: Includes integration tests to validate the system.

### Highlights

- **Migrations**: Manage database schema changes with EF Core migrations.
- **Integration Tests**: Validate the functionalities.
- **Code-First Approach**: The database schema is generated directly from the domain models, simplifying development and maintenance.
- **LINQ Support**: Seamlessly integrates with LINQ for querying data with hierarchical permissions.