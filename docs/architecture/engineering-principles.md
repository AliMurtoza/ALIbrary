# Engineering Principles

This document defines the engineering principles that guide the design, implementation, and maintenance of ALIbrary.

---

# Code Quality

- Prioritize readability over clever or overly compact code.
- Write small, focused methods with a single responsibility.
- Prefer explicit code over implicit behavior.
- Keep business logic out of controllers.
- Avoid premature optimization; optimize only when necessary.
- Eliminate dead code and unused dependencies.
- Follow consistent naming conventions throughout the solution.

---

# Architecture

- Follow Clean Architecture principles.
- Keep the Domain layer independent of external frameworks.
- Depend on abstractions rather than concrete implementations.
- Register dependencies through dedicated extension methods.
- Favor composition over inheritance where appropriate.
- Keep infrastructure concerns isolated from business logic.

---

# Domain Design

- Design the domain before implementing features.
- Model business concepts rather than database tables.
- Keep aggregates cohesive and focused.
- Avoid introducing new entities unless they solve a genuine business requirement.
- Separate library-owned data from user-specific data.

---

# Data Access

- Use Entity Framework Core with PostgreSQL.
- Configure relationships using Fluent API.
- Prefer asynchronous database operations.
- Enforce business rules through constraints and validation where appropriate.
- Use migrations for all schema changes; never modify the database manually.

---

# API Design

- Follow RESTful conventions.
- Use DTOs for request and response models.
- Never expose domain entities directly through API endpoints.
- Return appropriate HTTP status codes.
- Validate incoming requests before executing business logic.

---

# Git Workflow

- Follow Conventional Commits.
- Keep commits small, focused, and atomic.
- Write meaningful commit messages that explain *what* changed and *why*.
- Merge only working, buildable code into the main branch.
- Adopt a feature-branch workflow after the initial project skeleton is complete.

---

# Documentation

- Document significant architectural decisions using ADRs.
- Keep project documentation synchronized with implementation.
- Update development logs and project status at the end of every development session.
- Record future ideas in the roadmap instead of expanding the current scope.

---

# Testing

- Design code to be testable.
- Keep controllers thin and business logic independent.
- Test business rules rather than framework behavior.
- Write deterministic and repeatable tests.

---

# General Principles

- Simplicity is preferred over unnecessary complexity.
- Build for maintainability before extensibility.
- Every feature should provide clear value to the application.
- Avoid scope creep by following the agreed feature freeze.
- Leave the codebase in a better state than it was found.