# Project Plan

## Project Overview

ALIbrary is a modern Library Management System developed using **ASP.NET Core Web API**, **React**, **TypeScript**, **Material UI**, **Entity Framework Core**, **ASP.NET Identity**, and **PostgreSQL**.

The objective is to build a maintainable, scalable, and production-oriented application that demonstrates modern full-stack software engineering practices rather than simply satisfying minimum functional requirements.

---

# Vision

Create a complete digital platform capable of managing the daily operations of a library while maintaining a clean architecture, intuitive user experience, and extensible codebase.

Long-term goals include:

* Multi-branch library support
* Rich reporting
* Fine management
* Recommendation engine
* Reading history
* User bookshelves
* Notification system
* Production deployment

---

# Project Objectives

## Functional Objectives

* Secure authentication
* Role-based authorization
* Library resource management
* Borrow and return workflow
* Reservation management
* Dashboard analytics
* CRUD operations
* Search and filtering

---

## Technical Objectives

* Clean Architecture
* SOLID principles
* RESTful API
* Responsive frontend
* DTO-based communication
* Centralized exception handling
* Entity Framework Core
* JWT authentication
* Modular frontend structure

---

# Architecture Goals

The project is designed around several architectural principles.

## Separation of Concerns

Each layer has a single responsibility.

```id="vlw5e7"
Frontend

↓

API

↓

Application

↓

Infrastructure

↓

Database
```

---

## Loose Coupling

Business logic depends on interfaces rather than implementations.

Example

```id="yz7s31"
Controller

↓

IBookService

↓

BookService
```

This allows future replacement of implementations with minimal changes.

---

## Maintainability

The solution should remain understandable even as new modules are introduced.

Features are implemented independently wherever possible.

---

## Scalability

The architecture should support future additions without requiring significant refactoring.

Examples include:

* Branches
* Reports
* Notifications
* Barcode support
* Inventory
* Fine calculation

---

# Technology Stack

## Backend

* ASP.NET Core Web API
* C#
* Entity Framework Core
* ASP.NET Identity
* JWT Authentication
* PostgreSQL

---

## Frontend

* React
* TypeScript
* Material UI
* Axios
* React Router

---

## Development Tools

* Visual Studio
* Visual Studio Code
* Swagger
* Git
* GitHub
* Postman
* SourceTree

---

# Development Strategy

The project follows a feature-driven workflow.

Each module is developed independently using dedicated Git branches.

Example workflow

```id="pk5mbk"
main

↓

feature-books

↓

Pull Request

↓

main

↓

feature-dashboard

↓

Pull Request

↓

main
```

Every feature branch contains:

* Backend implementation
* Frontend implementation
* UI integration
* Manual verification
* Documentation update

---

# Development Phases

## Phase 1

Foundation

Completed

* Project setup
* Clean Architecture
* Authentication
* Authorization
* Database
* Identity
* JWT
* Seeders

Status

Completed

---

## Phase 2

Core Library Modules

Completed

* Dashboard
* Books
* Authors
* Members
* Loans
* Reservations

Status

Completed

---

## Phase 3

Remaining Functional Requirements

Planned

* Branch Management
* Reports
* Search improvements
* Pagination
* Validation enhancements

Status

Pending

---

## Phase 4

Production Improvements

Planned

* Unit testing
* Integration testing
* CI/CD
* Docker
* Cloud deployment
* Logging
* Monitoring

Status

Future

---

# Completed Modules

## Authentication

Completed

Features

* Registration
* Login
* JWT generation
* Identity integration
* Role management

---

## Dashboard

Completed

Features

* Total books
* Total authors
* Active loans
* Pending reservations
* Recent books

---

## Books

Completed

Features

* Create
* Read
* Update
* Delete
* Multiple authors
* Category
* Publisher
* Language

---

## Authors

Completed

Features

* Create
* Read
* Update
* Delete

---

## Members

Completed

Features

* Create
* Read
* Update
* Delete

---

## Loans

Completed

Features

* Borrow
* Return
* Status updates
* Copy availability tracking

---

## Reservations

Completed

Features

* Create reservation
* Cancel reservation
* Pending status tracking

---

# Current Progress

| Module            | Status     |
| ----------------- | ---------- |
| Authentication    | ✅ Complete |
| Dashboard         | ✅ Complete |
| Books             | ✅ Complete |
| Authors           | ✅ Complete |
| Members           | ✅ Complete |
| Loans             | ✅ Complete |
| Reservations      | ✅ Complete |
| Branch Management | ⏳ Planned  |
| Reports           | ⏳ Planned  |
| Testing           | ⏳ Planned  |
| Deployment        | ⏳ Planned  |

---

# Coding Standards

The project follows consistent coding conventions.

Backend

* PascalCase classes
* Dependency Injection
* Async methods
* DTO separation
* Interface-based services

Frontend

* Functional components
* Hooks
* Feature-based folders
* TypeScript interfaces
* Shared API services

---

# Git Workflow

Development follows a feature-branch strategy.

Example

```id="m2ub83"
main

↓

feature-books

↓

Pull Request

↓

main

↓

feature-authors

↓

Pull Request
```

Commit messages follow Conventional Commits.

Examples

```id="t7y7rx"
feat(books): implement book CRUD

feat(authors): add author management

feat(loans): implement borrowing workflow

fix(auth): seed default administrator

docs: update project documentation
```

---

# Testing Strategy

Current

* Manual testing
* Swagger verification
* Frontend verification

Planned

* Unit Tests
* Integration Tests
* API Tests
* UI Tests

---

# Quality Goals

The project aims to maintain:

* Readable code
* Small services
* Predictable APIs
* Reusable UI components
* Consistent styling
* Clear naming
* Minimal duplication

---

# Risks

Potential risks include:

* Missing automated tests
* Growing feature complexity
* Increasing database relationships
* Future performance bottlenecks
* Deployment configuration differences

These will be addressed in future iterations.

---

# Future Enhancements

Planned improvements include:

* Branch Management
* Reporting Dashboard
* Advanced Search
* Pagination
* Sorting
* Fine Calculation
* Email Notifications
* Inventory Analytics
* Reading Statistics
* Recommendation Engine
* Docker Support
* Azure Deployment
* GitHub Actions CI/CD
* Automated Testing

---

# Success Criteria

The project will be considered mature when it provides:

* Secure authentication
* Role-based authorization
* Complete library workflows
* Responsive user interface
* Clean Architecture
* Production-ready documentation
* Automated testing
* Continuous deployment
* Cloud-hosted environment

---

# Guiding Principles

Throughout development, the project prioritizes:

1. Correctness over speed.
2. Maintainability over cleverness.
3. Readability over brevity.
4. Incremental improvement through small feature branches.
5. Consistent architecture across backend and frontend.
6. A codebase that can continue evolving into a production-grade library management platform.
