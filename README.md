# HealthVision-CDS

[![.NET CI](https://github.com/sandrajos/HealthVision-CDS/actions/workflows/dotnet-ci.yml/badge.svg)](https://github.com/sandrajos/HealthVision-CDS/actions/workflows/dotnet-ci.yml)

## Educational Healthcare Workflow API

HealthVision-CDS is an educational backend project built with ASP.NET Core and C# to explore healthcare-oriented data workflows, REST API design, layered architecture, and persistence with Entity Framework Core.

> Project scope: This is a learning and portfolio project. It is not intended for production healthcare use, clinical decision-making, or processing real patient data.

## Overview

The current implementation provides:

- RESTful patient CRUD API
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server integration
- Swagger / OpenAPI
- Dependency injection
- Database initialization and sample data seeding
- Patient and Study domain entities
- Entity Framework Core migrations
- HTTPS redirection
- Dedicated xUnit test project

## REST API

Base route:

/api/patients

Available endpoints:

- GET /api/patients
- GET /api/patients/{id}
- POST /api/patients
- PUT /api/patients/{id}
- DELETE /api/patients/{id}

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Application development |
| ASP.NET Core | REST API |
| Entity Framework Core | ORM and data access |
| SQL Server | Relational database |
| Swagger / OpenAPI | API documentation |
| .NET | Application platform |
| xUnit | Test project |
| Git | Version control |

## Project Structure

HealthVision-CDS/
├── src/
│   ├── HealthVision.API/
│   ├── HealthVision.Application/
│   ├── HealthVision.Domain/
│   └── HealthVision.Infrastructure/
├── tests/
│   └── HealthVision.Tests/
├── HealthVision.slnx
└── README.md

## Engineering Concepts

This project explores:

- Layered application architecture
- Separation of API, domain, and infrastructure concerns
- RESTful API design
- Dependency injection
- Entity Framework Core
- SQL Server persistence
- Database migrations
- Swagger / OpenAPI
- Configuration management
- .NET testing structure

## Running the Project

Prerequisites:

- .NET SDK compatible with the project
- SQL Server
- Git

Clone the repository:

git clone https://github.com/sandrajos/HealthVision-CDS.git
cd HealthVision-CDS

Configure the SQL Server connection string in:

src/HealthVision.API/appsettings.json

Run the API:

dotnet run --project src/HealthVision.API

Swagger UI is enabled when the application runs in the Development environment.

## Testing

A dedicated xUnit test project is included under:

tests/HealthVision.Tests

The project includes an xUnit test project covering the patient API controller.

Current tests include:

- Retrieving the patient list successfully
- Returning `404 Not Found` for a missing patient
- Creating and persisting a patient successfully

Tests use **EF Core InMemory** for isolated test execution and are automatically executed by the **GitHub Actions CI pipeline**.

## Current Limitations

This is an educational portfolio project and is not a production healthcare system.

It currently does not provide:

- Clinical decision-making functionality
- AI/ML-based diagnosis or recommendations
- Authentication and authorization
- Production-grade patient-data security
- Comprehensive automated test coverage
- Production deployment infrastructure
- Healthcare regulatory compliance implementation

## Future Improvements

Potential improvements include:

- Add service-layer implementations
- Introduce DTOs and validation
- Expand patient and study workflows
- Add comprehensive unit and integration tests
- Add authentication and authorization
- Improve exception handling
- Add structured logging and monitoring
- Extend GitHub Actions CI/CD with deployment automation
- Containerize the API with Docker
- Add health checks
- Add API versioning
- Explore AI-assisted clinical decision-support concepts in a clearly separated educational module

## Portfolio Context

HealthVision-CDS demonstrates backend development with C#, ASP.NET Core, REST APIs, Entity Framework Core, SQL Server, and layered application architecture.

The project provides a foundation for extending the application with testing, Docker, CI/CD, cloud deployment, and infrastructure automation.

---

Author: Sandra Jose
