# OrderManagement API

> **ASP.NET Core Web API for managing products, users, and orders using Clean Architecture.**

🚧 **Status: In Progress / Active Development**

## Overview

**OrderManagement** is a backend-focused REST API built with **.NET 8**, designed to demonstrate a maintainable and production-oriented approach to building an order management system.

The project currently includes user authentication, product management, stock handling, and order placement, with additional features and improvements under development.

---

## Features

### Authentication

* User login
* JWT token generation
* Role-based claims
* Protected API endpoints

### Product Management

* Create product
* Get product by ID
* Get all products
* Pagination
* Update product
* Soft delete product
* Product request validation
* Stock quantity management

### Order Management

* Place an order
* Validate user
* Validate products
* Validate product availability
* Validate stock quantity
* Automatically reduce product stock
* Create order and order items
* Calculate order total

### API Infrastructure

* Global exception handling
* Consistent API response models
* Pagination response model
* FluentValidation
* Serilog logging
* Swagger / OpenAPI
* Entity Framework Core migrations

---

## Architecture

The solution follows a **Clean Architecture** approach:

```text
┌──────────────────────────────┐
│     OrderManagement.API      │
│      ASP.NET Core Web API    │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│ OrderManagement.Application  │
│                              │
│ Requests / Responses         │
│ Handlers / Use Cases         │
│ Validation                   │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│    OrderManagement.Domain    │
│                              │
│ Entities / Business Rules    │
└──────────────────────────────┘

┌──────────────────────────────┐
│ OrderManagement.Infrastructure│
│                              │
│ EF Core / Repositories       │
│ Unit of Work / DB Access     │
└──────────────┬───────────────┘
               │
               ▼
          SQL Server
```

### Projects

| Project                          | Responsibility                                          |
| -------------------------------- | ------------------------------------------------------- |
| `OrderManagement.API`            | API endpoints, middleware and application startup       |
| `OrderManagement.Application`    | Use cases, requests, responses, handlers and validation |
| `OrderManagement.Domain`         | Core entities and business concepts                     |
| `OrderManagement.Infrastructure` | Database access, EF Core, repositories and Unit of Work |

---

## Technology Stack

* **C#**
* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **MediatR**
* **FluentValidation**
* **JWT Authentication**
* **Serilog**
* **Swagger / OpenAPI**
* **Postman**

---

## Design Patterns & Practices

The project currently uses:

* Clean Architecture
* Dependency Injection
* Repository Pattern
* Unit of Work
* CQRS-style request/handler approach with MediatR
* DTO / Request / Response models
* Global exception handling
* FluentValidation
* JWT authentication
* Soft deletion

The architecture keeps business logic separated from API and database implementation details.

---

## API Workflow

### Product Creation

```text
POST /api/products
        ↓
Validation
        ↓
CreateProductHandler
        ↓
Repository
        ↓
SQL Server
```

### Order Placement

```text
POST /api/orders
        ↓
Validate User
        ↓
Validate Products
        ↓
Check Stock
        ↓
Calculate Order Total
        ↓
Reduce Stock
        ↓
Create Order + Order Items
        ↓
Unit of Work
        ↓
SQL Server
```

---

## Getting Started

### Prerequisites

Make sure the following are installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/)
* SQL Server
* Visual Studio 2022 or another .NET-compatible IDE
* Postman *(optional, for API testing)*

### Clone the Repository

```bash
git clone <repository-url>
cd OrderManagement
```

### Configure Database

Update the SQL Server connection string in the application configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=OrderManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Apply Migrations

```bash
dotnet ef database update
```

### Run the API

```bash
dotnet run
```

Swagger can then be used to explore and test the available endpoints.

---

## Project Status

🚧 **In Development**

### Currently Implemented

* Clean Architecture solution
* SQL Server and EF Core integration
* User authentication
* JWT token generation
* Product CRUD
* Product pagination
* Product soft deletion
* Stock management
* Order placement
* Repository and Unit of Work
* FluentValidation
* Global exception handling
* Serilog logging
* MediatR-based request/handler flow

### Planned / Ongoing

* Expanded unit and integration testing
* Additional order workflows
* Further authorization improvements
* API performance improvements
* CI/CD pipeline
* Azure deployment
* Additional production-readiness improvements

---

## API Testing

The API can be tested using:

* Swagger / OpenAPI
* Postman

Typical workflow:

```text
Login
  ↓
Get JWT Token
  ↓
Authorize API
  ↓
Create / Manage Products
  ↓
Place Order
  ↓
Verify Stock & Order
```

---

## Purpose

This project is being developed as a **portfolio and learning project** to demonstrate practical experience with modern **C#, ASP.NET Core, REST APIs, SQL Server, Clean Architecture, authentication, validation, and backend development practices**.

---

## License

This project is intended for portfolio and educational purposes.
