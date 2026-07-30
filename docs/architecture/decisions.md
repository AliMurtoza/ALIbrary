# Architecture Decisions

This document records significant architectural decisions made throughout the development of ALIbrary. Each Architecture Decision Record (ADR) captures the context, the decision made, and the rationale behind it.

---

# ADR-001 — Target Framework

## Status

Accepted

## Decision

The backend will be built using **.NET 8 (LTS)**.

## Rationale

- Long-Term Support (LTS) for production stability.
- Mature ecosystem with excellent tooling.
- Strong compatibility with Entity Framework Core and ASP.NET Core.
- Avoids adopting a non-LTS framework for a long-term portfolio project.

---

# ADR-002 — Database

## Status

Accepted

## Decision

PostgreSQL will be used as the primary relational database.

## Rationale

- Recommended by the project requirements.
- Excellent support in Entity Framework Core.
- Open-source, reliable, and production-proven.
- Supports advanced indexing and querying capabilities required for future expansion.

---

# ADR-003 — Architecture

## Status

Accepted

## Decision

The solution follows the Clean Architecture pattern.

## Rationale

- Separates business logic from infrastructure concerns.
- Encourages maintainability and testability.
- Makes future replacement of external technologies significantly easier.
- Provides a scalable structure suitable for real-world applications.

---

# ADR-004 — Dependency Management

## Status

Accepted

## Decision

Dependencies will be managed using Dependency Injection, with repositories and infrastructure services registered through dedicated extension methods.

## Rationale

- Promotes loose coupling between layers.
- Simplifies testing and future service replacement.
- Keeps application startup organized and maintainable.
- Aligns with ASP.NET Core best practices.

---

# ADR-005 — Domain-First Design

## Status

Accepted

## Decision

The complete domain model will be designed before implementing entities and business logic.

## Rationale

- Reduces future refactoring.
- Establishes consistent relationships across the entire system.
- Provides a stable blueprint for implementation.
- Ensures business rules are considered before writing code.

---

# ADR-006 — Book vs. BookCopy

## Status

Accepted

## Decision

A logical book and its physical copies are modeled as separate entities.

## Rationale

A single title may have multiple physical copies, each with its own barcode, condition, shelf location, and availability status.

This design reflects how real-world libraries operate and simplifies circulation management.

---

# ADR-007 — UserBook Aggregate

## Status

Accepted

## Decision

A `UserBook` aggregate represents a member's personal relationship with a book.

## Rationale

Instead of introducing multiple independent entities for reading status, favorites, and user-specific metadata, `UserBook` acts as the central aggregate for all user-book interactions.

This keeps the domain cohesive while reducing duplication.

---

# ADR-008 — Reading Progress

## Status

Accepted

## Decision

Reading progress is modeled as a separate entity associated with `UserBook`.

## Rationale

Reading progress changes frequently and represents a distinct concern from the user's overall relationship with a book.

Separating it improves maintainability and allows future enhancements without modifying the core aggregate.

---

# ADR-009 — Feature Freeze

## Status

Accepted

## Decision

After the domain model is finalized, new entities will only be introduced if they:

- Are required by business requirements.
- Are required by the project specification.
- Resolve a genuine architectural limitation.

## Rationale

This prevents unnecessary scope expansion, keeps implementation focused, and increases the likelihood of delivering a polished Version 1 within the planned development timeline.