# .NET Clean Architecture API

A modern ASP.NET Core Web API built using **Clean Architecture** and **Vertical Slice principles**, featuring JWT authentication, role-based authorization, and EF Core with SQLite.

---

## 🚀 Features

- ASP.NET Core Web API (.NET 8/10 style minimal hosting)
- Clean Architecture (Domain, Application, Infrastructure, API)
- Vertical Slice-inspired feature structure
- Entity Framework Core with SQLite
- JWT Authentication (Bearer tokens)
- Role-based Authorization
- Password hashing using ASP.NET Core Identity
- Swagger (OpenAPI) with Authorize support
- Dependency Injection throughout
- Async/await for all data access

---

## 🧱 Architecture Overview

The solution is split into four projects:
MyApi.sln

MyApi.Domain/
Entities/

MyApi.Application/
Abstractions/

MyApi.Infrastructure/
Data/
Repositories/
Auth/

MyApi.Api/
Controllers/
Features/
Auth/

### Responsibilities

- **Domain**
  - Core business entities (`User`, `Product`)
  - No dependencies

- **Application**
  - Interfaces (repositories, services)
  - Business contracts

- **Infrastructure**
  - EF Core (DbContext)
  - Repository implementations
  - Password hashing

- **API**
  - Controllers
  - Feature folders (vertical slice style)
  - JWT auth setup
  - Swagger configuration

---

## 🔐 Authentication & Authorization

- JWT Bearer authentication
- Tokens include:
  - `sub` (user id)
  - `email`
  - `role`
- Role-based access via:

###```csharp
##[Authorize(Roles = "Admin")]

## Passwords are stored securely using hashing (no plain text)

### API Endpoints

## Auth
POST /api/auth/login
{
  "email": "admin@test.com",
  "password": "Password123!"
}

## Products
GET    /api/products
GET    /api/products/{id}
POST   /api/products
PUT    /api/products/{id}
DELETE /api/products/{id}

### Tech Stack
- .NET (ASP.NET Core Web API)
- Entity Framework Core
- SQLite
- JWT (Microsoft.AspNetCore.Authentication.JwtBearer)
- Swagger (Swashbuckle)

### Future Improvements
- Global exception handling middleware
- ProblemDetails error responses
- Pagination and filtering for products
- Integration and unit tests
- Refresh tokens / token rotation
- Docker support
- CI/CD pipeline

### Summary
This project demonstrates how to build a modern, production-style .NET API with:

- Clean separation of concerns
- Secure authentication
- Scalable architecture
- Real-world backend patterns

