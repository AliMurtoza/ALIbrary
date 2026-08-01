# Architecture Decisions

This document records important architectural and design decisions made during the development of **ALIbrary**. Each decision captures the reasoning behind a particular approach, the alternatives considered, and the expected long-term impact on the project.

---

# ADR-001 — Adopt Clean Architecture

## Status

Accepted

## Decision

The backend follows a layered Clean Architecture consisting of:

* API
* Application
* Infrastructure
* Domain

## Rationale

This separates business logic from infrastructure concerns and improves maintainability.

Benefits include:

* Better testability
* Loose coupling
* Clear project organization
* Easier future expansion

---

# ADR-002 — Use ASP.NET Identity for Authentication

## Status

Accepted

## Decision

Authentication and user management are handled using ASP.NET Identity.

## Rationale

Identity provides production-ready implementations for:

* Password hashing
* User management
* Role management
* Authentication integration

This avoids building custom authentication logic.

---

# ADR-003 — Use JWT Authentication

## Status

Accepted

## Decision

The frontend authenticates using JSON Web Tokens.

## Rationale

JWT enables:

* Stateless authentication
* Easy frontend integration
* Secure API communication
* Scalability for future deployments

---

# ADR-004 — Use Entity Framework Core

## Status

Accepted

## Decision

Entity Framework Core is used as the ORM.

## Rationale

Benefits include:

* Strong LINQ support
* Migration management
* Change tracking
* Tight ASP.NET integration

---

# ADR-005 — DTO-Based API Communication

## Status

Accepted

## Decision

The API never exposes Entity Framework entities directly.

DTOs are used for all requests and responses.

## Rationale

Benefits include:

* Stable API contracts
* Better security
* Prevents over-posting
* Decouples frontend from persistence models

---

# ADR-006 — Service Layer for Business Logic

## Status

Accepted

## Decision

Controllers delegate all business logic to services.

## Rationale

Controllers remain thin and focused on HTTP concerns.

Business rules remain centralized and reusable.

---

# ADR-007 — Feature-Based Git Workflow

## Status

Accepted

## Decision

Each major feature is developed on its own Git branch.

Examples:

* feature-books
* feature-dashboard
* feature-authors
* feature-loans

## Rationale

Benefits include:

* Smaller pull requests
* Easier reviews
* Reduced merge conflicts
* Better development history

---

# ADR-008 — Material UI for Frontend

## Status

Accepted

## Decision

Material UI is used as the primary component library.

## Rationale

It provides:

* Responsive components
* Accessibility
* Consistent styling
* Faster UI development

---

# ADR-009 — Axios API Layer

## Status

Accepted

## Decision

Frontend API communication is centralized using Axios services.

## Rationale

Benefits include:

* Shared configuration
* Token injection
* Easier maintenance
* Cleaner React components

---

# ADR-010 — Dashboard Uses Aggregated API

## Status

Accepted

## Decision

Dashboard statistics are retrieved from a dedicated endpoint instead of multiple API calls.

## Rationale

Benefits include:

* Fewer HTTP requests
* Better performance
* Simpler frontend
* Centralized dashboard logic

---

# ADR-011 — Book–Author Relationship Uses Many-to-Many Mapping

## Status

Accepted

## Decision

Books and Authors are connected through the `BookAuthor` junction entity.

## Rationale

A book may have multiple authors, and an author may write multiple books.

This design supports future expansion without schema changes.

---

# ADR-012 — Book CRUD Supports Multiple Authors

## Status

Accepted

## Decision

Book creation and updates allow selecting multiple authors.

The backend manages junction table updates.

## Rationale

This reflects real-world library data and removes manual database updates.

---

# ADR-013 — Custom Confirmation Dialogs

## Status

Accepted

## Decision

Delete operations use Material UI dialogs instead of browser confirmation dialogs.

## Rationale

Benefits include:

* Consistent UI
* Better user experience
* Easier customization

---

# ADR-014 — Centralized Exception Handling

## Status

Accepted

## Decision

Unhandled exceptions are processed by a global exception middleware.

## Rationale

Benefits include:

* Consistent error responses
* Cleaner controllers
* Centralized logging opportunities

---

# ADR-015 — Role Seeding at Startup

## Status

Accepted

## Decision

Application startup seeds required roles automatically.

Current roles:

* Admin
* Member

## Rationale

Ensures required roles always exist without manual setup.

---

# ADR-016 — Default Administrator Seeding

## Status

Accepted

## Decision

A default administrator account is seeded during application startup if it does not already exist.

## Rationale

This removes the need to manually promote users during development and ensures administrative functionality is immediately available after first launch.

---

# ADR-017 — Manual CRUD Before Generic Components

## Status

Accepted

## Decision

CRUD pages are implemented individually instead of introducing generic reusable CRUD components.

## Rationale

For the current project size, explicit implementations are easier to understand and modify. Shared abstractions can be introduced later if the application grows significantly.

---

# ADR-018 — Manual Testing Before Automated Testing

## Status

Accepted

## Decision

Development currently relies on manual testing through Swagger and the React frontend.

## Rationale

Given project constraints and assessment priorities, functional features were prioritized over automated test coverage.

Automated testing remains a planned enhancement.

---

# ADR-019 — Technical Debt: Book Copy Selection

## Status

Deferred

## Decision

Loan creation currently requires selecting a specific book copy rather than automatically assigning an available copy.

## Rationale

Automatic copy allocation is a desirable enhancement but was deferred to keep the current implementation aligned with project scope and available development time.

---

# ADR-020 — Technical Debt: Reporting Module

## Status

Deferred

## Decision

The reporting module defined in the assessment requirements has not yet been implemented.

## Rationale

Core library operations were prioritized first. Reporting will be introduced in a future iteration after completing remaining functional requirements.

---

# Future Decisions

Additional Architecture Decision Records will be created as new architectural choices arise, including:

* Branch management architecture
* Reporting design
* Automated testing strategy
* Docker deployment
* CI/CD pipeline
* Caching strategy
* Logging and monitoring
* Background jobs
* Notification system
