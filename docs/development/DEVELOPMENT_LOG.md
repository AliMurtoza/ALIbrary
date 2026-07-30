# Development Log

---

# Session 1

**Date:** July 29, 2026

**Duration:** ~1–2 hours

## Objectives

Initialize the project and establish the development foundation.

---

## Completed

### Repository & Solution

- Initialized the GitHub repository.
- Established the monorepo structure.
- Created the backend solution.
- Added the API, Application, Domain, Infrastructure, and Tests projects.
- Targeted .NET 8 LTS.
- Configured project references.

---

## Key Decisions

- Use .NET 8 LTS.
- Adopt Clean Architecture.
- Organize the project as a modular monorepo.

---

# Session 2

**Date:** July 30, 2026

**Duration:** ~8–10 hours

## Objectives

Complete the backend foundation, finalize the domain model, and establish the database layer.

---

## Completed

### Project Setup

- Installed required NuGet packages.
- Configured Dependency Injection.
- Configured application settings.
- Configured Swagger.
- Verified successful solution builds.

### Database

- Installed PostgreSQL and pgAdmin 4.
- Created the `ALIbraryDb` database.
- Configured Entity Framework Core.
- Implemented Fluent API configurations.
- Generated the initial migration.
- Successfully created the PostgreSQL schema.

### Architecture & Domain

- Finalized the Version 1 domain model.
- Implemented all domain entities.
- Configured entity relationships.
- Introduced UserBook, ReadingProgress, and Bookshelves.
- Declared a Version 1 feature freeze.

### Documentation

- Established the project documentation structure.
- Recorded architecture decisions.
- Defined engineering principles.
- Created the project plan, ERD, and system design documents.
- Updated project documentation to reflect implementation progress.

---

## Key Decisions

- Use PostgreSQL with Entity Framework Core.
- Use Repository Pattern with Dependency Injection.
- Separate `Book` from `BookCopy`.
- Model personal reading through `UserBook`.
- Freeze the Version 1 domain model before feature development.