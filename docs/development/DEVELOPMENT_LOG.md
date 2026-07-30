# Development Log

---

# Session 1

**Date:** July 29, 2026

**Duration:** ~6–8 hours

## Objectives

Establish the project foundation, define the architecture, and prepare the development environment.

---

## Completed

### Repository & Solution

- Created the GitHub repository and initialized the project.
- Established the monorepo structure.
- Created the backend solution.
- Added the following projects:
  - ALIbrary.Api
  - ALIbrary.Application
  - ALIbrary.Domain
  - ALIbrary.Infrastructure
- Targeted .NET 8 LTS across the solution.
- Configured project references.

### Project Setup

- Installed required NuGet packages.
- Configured Dependency Injection.
- Updated application configuration.
- Verified the application builds successfully.
- Configured Swagger.

### Database

- Installed PostgreSQL.
- Installed pgAdmin 4.
- Created the `ALIbraryDb` database.
- Verified the local PostgreSQL environment.

### Documentation

- Established the documentation structure.
- Created architecture and development documentation.
- Defined engineering principles.
- Recorded architecture decisions (ADRs).
- Created the project plan.
- Designed and finalized the domain model.
- Established project documentation standards.

### Architecture

- Adopted Clean Architecture.
- Finalized the core domain model.
- Defined entity relationships.
- Introduced the UserBook aggregate.
- Introduced ReadingProgress.
- Included Bookshelves as a Version 1 feature.
- Declared a feature freeze to prevent unnecessary scope expansion.

---

## Key Decisions

- Use .NET 8 LTS.
- Use PostgreSQL.
- Follow Clean Architecture.
- Use Repository Pattern with Dependency Injection.
- Separate `Book` from `BookCopy`.
- Model user interactions through `UserBook`.
- Keep `ReadingProgress` as a separate entity.
- Reserve future enhancements for the roadmap instead of Version 1.