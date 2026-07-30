# ALIbrary Project Plan

## Overview

ALIbrary is a modern digital library platform designed to provide a scalable, maintainable, and user-friendly solution for managing library resources and enhancing the personal reading experience of its members.

The platform combines traditional library operations with personal reading features, following Clean Architecture principles and modern software engineering practices.

---

# Project Objectives

## Functional Objectives

- Manage books and physical book copies
- Manage authors, publishers, categories, and languages
- Support secure user authentication and authorization
- Handle book borrowing, returning, and reservations
- Allow members to track their reading progress
- Enable book reviews and ratings
- Support custom bookshelves for personal organization

---

## Engineering Objectives

- Follow Clean Architecture principles
- Produce clean, maintainable, production-quality code
- Build a secure RESTful API
- Maintain comprehensive project documentation
- Keep the application deployable throughout development

---

# Technology Stack

## Backend

- ASP.NET Core 8 Web API
- Entity Framework Core
- PostgreSQL
- ASP.NET Core Identity
- JWT Bearer Authentication

---

## Frontend

- React
- TypeScript
- Vite

---

## Development Tools

- Visual Studio 2026
- Visual Studio Code
- SourceTree
- pgAdmin 4
- Postman

---

# Architectural Principles

- Clean Architecture
- Repository Pattern
- Dependency Injection
- Service Layer
- Domain-First Design

---

# Development Strategy

The project follows an incremental, feature-by-feature development approach.

Key principles include:

- Keep the solution in a working state after every development session.
- Prefer small, focused commits.
- Update project documentation after each session.
- Finalize architectural decisions before implementation.
- Prioritize maintainability over unnecessary complexity.

---

# Development Phases

## Phase 1 — Foundation

- Repository setup
- Solution structure
- Project configuration
- Dependency setup
- Documentation

---

## Phase 2 — Domain

- Domain model
- Entity design
- Database design
- Entity relationships
- Initial database migration

---

## Phase 3 — Authentication

- ASP.NET Identity
- JWT Authentication
- Role management
- Authorization

---

## Phase 4 — Library Management

- Books
- Book copies
- Authors
- Publishers
- Categories
- Languages

---

## Phase 5 — Circulation

- Borrowing
- Returning
- Reservations

---

## Phase 6 — Personal Reading Space

- UserBook
- Reading progress
- Reviews and ratings
- Bookshelves

---

## Phase 7 — Frontend

- React application
- Authentication
- Dashboard
- CRUD interfaces
- Personal reading features

---

## Phase 8 — Testing & Deployment

- Testing
- Bug fixing
- Performance improvements
- Documentation review
- Deployment preparation

---

# Current Progress

## Completed

- Repository initialized
- Solution structure created
- Clean Architecture projects created
- .NET 8 configured
- Project references configured
- Required NuGet packages installed
- Dependency Injection configured
- PostgreSQL installed and configured
- Database created
- Initial documentation completed
- Domain model finalized

---

## Currently In Progress

- Domain entity implementation

---

## Remaining Work

- Implement domain entities
- Configure Entity Framework Core
- Create initial migration
- Authentication and authorization
- Business logic
- REST API endpoints
- React frontend
- Testing
- Deployment

---

# Definition of Success

The project will be considered complete when:

- All planned Version 1 features are implemented.
- Backend and frontend are fully integrated.
- The application runs successfully using PostgreSQL.
- Documentation accurately reflects the implementation.
- The repository demonstrates production-quality software engineering practices suitable for a professional portfolio.