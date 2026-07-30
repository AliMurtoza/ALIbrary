# System Design

## Overview

ALIbrary follows **Clean Architecture** to separate business logic from infrastructure and presentation concerns.

The backend exposes a RESTful API consumed by a React frontend, with PostgreSQL serving as the primary database.

---

## High-Level Architecture

```
React (TypeScript + Vite)
            │
            ▼
 ASP.NET Core Web API
            │
            ▼
     Application Layer
            │
            ▼
       Domain Layer
            │
            ▼
  Infrastructure Layer
            │
            ▼
       PostgreSQL
```

---

## Solution Structure

```
backend/
├── ALIbrary.Api
├── ALIbrary.Application
├── ALIbrary.Domain
└── ALIbrary.Infrastructure
```

---

## Layer Responsibilities

| Layer | Responsibility |
|--------|----------------|
| API | HTTP endpoints, authentication, request/response handling |
| Application | Business use cases, DTOs, interfaces, validation |
| Domain | Entities, enums, business rules |
| Infrastructure | EF Core, database access, repositories, external services |

---

## Key Technologies

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- ASP.NET Core Identity
- JWT Authentication
- React
- TypeScript
- Vite

---

## Design Principles

- Clean Architecture
- Dependency Injection
- Repository Pattern
- Domain-First Design
- RESTful API Design