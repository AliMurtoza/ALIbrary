# System Design

## Overview

ALIbrary follows a layered **Clean Architecture** to separate business logic from infrastructure concerns and presentation. The solution is divided into independent backend and frontend applications communicating through a RESTful API secured with JWT authentication.

The architecture emphasizes:

* Separation of Concerns
* Dependency Inversion
* SOLID Principles
* Maintainability
* Testability
* Scalability

---

# High-Level Architecture

```
                    +-------------------------+
                    |   React Frontend (UI)   |
                    |     React + MUI + TS    |
                    +------------+------------+
                                 |
                          HTTPS / REST API
                                 |
                    +------------v------------+
                    | ASP.NET Core Web API    |
                    | Controllers             |
                    +------------+------------+
                                 |
                          Application Layer
                                 |
                    +------------v------------+
                    | Business Services       |
                    | DTOs                    |
                    | Interfaces              |
                    +------------+------------+
                                 |
                         Infrastructure Layer
                                 |
                    +------------v------------+
                    | Entity Framework Core   |
                    | Identity                |
                    | PostgreSQL              |
                    +------------+------------+
                                 |
                          PostgreSQL Database
```

---

# Backend Architecture

The backend follows **Clean Architecture**.

```
API
│
├── Controllers
│
Application
│
├── DTOs
├── Interfaces
└── Authentication
│
Infrastructure
│
├── Services
├── Data
├── Identity
├── DependencyInjection
└── Seed
│
Domain
│
├── Entities
├── Enums
└── Common
```

Dependencies always point inward.

```
API
 ↓
Application
 ↓
Domain

Infrastructure
 ↑
implements Application interfaces
```

Business logic never depends directly on Entity Framework, Identity, or ASP.NET Core.

---

# Frontend Architecture

The frontend is built using **React + TypeScript** and follows a feature-oriented structure.

```
src
│
├── api
│
├── components
│
├── layouts
│
├── pages
│     ├── Dashboard
│     ├── Books
│     ├── Authors
│     ├── Members
│     ├── Loans
│     └── Reservations
│
├── routes
│
├── services
│
├── types
│
└── utils
```

Responsibilities:

* Pages contain UI composition.
* Services perform API communication.
* Types define API contracts.
* Layouts provide navigation and application shell.
* API client centralizes Axios configuration.

---

# Authentication Flow

```
User
 │
 │ Login
 ▼
POST /api/Auth/login
 │
 ▼
JWT Token
 │
 ▼
Stored in Local Storage
 │
 ▼
Axios Authorization Header
 │
 ▼
Authenticated API Requests
```

Protected endpoints require a valid JWT token.

Administrative operations additionally require:

```
[Authorize(Roles = "Admin")]
```

---

# Authorization Model

Two roles currently exist.

```
Admin

• Dashboard
• Books
• Authors
• Members
• Loans
• Reservations
• CRUD Operations

------------------------

Member

(Currently limited)

Future capabilities:

• Personal profile
• Borrow history
• Reservations
• Bookshelves
• Reading progress
```

---

# Database Design

Core entities include:

```
Book
Author
BookAuthor

Publisher
Language
Category

BookCopy

Member

Loan

Reservation

ApplicationUser
IdentityRole
```

Relationships

```
Book
 ├── Publisher
 ├── Language
 ├── Category
 ├── BookCopies
 ├── Reservations
 └── BookAuthors

Author
 └── BookAuthors

Member
 ├── Loans
 └── Reservations

Loan
 └── BookCopy

Reservation
 └── Book
```

---

# Book Module

Implemented features

* Create Book
* Edit Book
* Delete Book
* List Books
* Search-ready backend
* Category selection
* Language selection
* Publisher selection
* Multiple Authors

Books maintain a many-to-many relationship with authors through the BookAuthor junction table.

---

# Author Module

Implemented features

* Create
* Read
* Update
* Delete

Authors can be assigned to one or multiple books.

---

# Member Module

Implemented features

* Create
* Read
* Update
* Delete

Members are later used for:

* Borrowing
* Reservations
* Reading history

---

# Loan Module

Borrow workflow

```
Member
     │
Select Copy
     │
Borrow
     │
Loan Created
     │
BookCopy Status
Available
      ↓
Borrowed
```

Return workflow

```
Return Book
      │
ReturnedAt updated
      │
Loan Status
Returned
      │
BookCopy Status
Borrowed
      ↓
Available
```

Business validations

* Member must exist
* Copy must exist
* Copy must be Available
* Closed loans cannot be returned again

---

# Reservation Module

Reservation flow

```
Member
      │
Reserve Book
      │
Reservation
Status = Pending
      │
Cancel
      │
Status = Cancelled
```

Only pending reservations can be cancelled.

---

# Dashboard

Dashboard aggregates key system metrics.

Displayed information

* Total Books
* Total Authors
* Active Loans
* Pending Reservations

Recent books are also displayed.

Dashboard data is retrieved through a dedicated endpoint instead of multiple API requests.

---

# API Design

The API follows REST principles.

Example endpoints

```
GET    /api/books

POST   /api/books

PUT    /api/books/{id}

DELETE /api/books/{id}

----------------------------

GET    /api/authors

POST   /api/authors

PUT    /api/authors/{id}

DELETE /api/authors/{id}

----------------------------

POST   /api/loans/borrow

POST   /api/loans/{id}/return

----------------------------

POST   /api/reservations

POST   /api/reservations/{id}/cancel
```

Responses use DTOs instead of exposing EF entities.

---

# Error Handling

A centralized exception middleware converts exceptions into consistent HTTP responses.

Examples

```
404 Not Found

400 Bad Request

401 Unauthorized

403 Forbidden
```

Custom exceptions include:

* NotFoundException
* BadRequestException

---

# Data Transfer Objects

Communication between frontend and backend uses DTOs.

Example

```
Book

↓

BookResponse

↓

JSON

↓

React UI
```

This prevents over-posting and avoids exposing internal entity models.

---

# Dependency Injection

Services are registered through the Infrastructure dependency injection extension.

Example layers

```
Controller

↓

IBookService

↓

BookService

↓

ApplicationDbContext
```

Controllers depend on interfaces rather than concrete implementations.

---

# Security

Implemented

* JWT Authentication
* ASP.NET Identity
* Role-based Authorization
* Password hashing
* Protected endpoints
* Secure middleware pipeline

Current token storage

```
Local Storage
```

Future enhancement

* Refresh Tokens
* HttpOnly Cookies

---

# UI Design Principles

The frontend follows a consistent Material UI design.

Characteristics

* Responsive layouts
* Card-based dashboard
* Consistent dialogs
* Confirmation dialogs
* Shared spacing
* Feature-based navigation
* Material icons
* Uniform typography

The Books, Authors, Members, Loans, and Reservations modules intentionally share the same visual language for consistency.

---

# Scalability

The current architecture supports future expansion with minimal refactoring.

Planned modules

* Branch Management
* Reports
* Fine Management
* Notifications
* Email Service
* Audit Logging
* Barcode Printing
* Inventory Management
* User Bookshelves
* Reading Progress
* Recommendation Engine

---

# Deployment Architecture

Current development environment

```
React
    │
localhost:5173

↓

ASP.NET Core API
localhost:7281

↓

PostgreSQL
```

Production target

```
React
    │
Azure Static Web Apps
(or Vercel)

↓

ASP.NET Core API
Azure App Service

↓

Azure Database for PostgreSQL
```

---

# Architectural Strengths

* Clean Architecture
* Layered design
* Dependency Injection
* SOLID-friendly implementation
* Feature-oriented frontend
* RESTful API
* Strong separation between UI and business logic
* DTO-based communication
* JWT authentication
* Role-based authorization
* Centralized exception handling
* Scalable project structure

These decisions provide a maintainable foundation that can continue to grow into a production-grade library management platform without requiring significant architectural changes.
