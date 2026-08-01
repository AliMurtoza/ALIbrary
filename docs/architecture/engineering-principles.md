# Engineering Principles

This project follows a set of engineering principles intended to keep the codebase maintainable, scalable, and easy to evolve over time. These principles guide architectural decisions, coding style, feature development, and collaboration.

---

# 1. Clean Architecture

The solution follows Clean Architecture to separate business logic from infrastructure and presentation concerns.

Each layer has a clearly defined responsibility.

```text
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

Business logic remains independent of frameworks and external technologies.

---

# 2. Separation of Concerns

Every component should have one well-defined responsibility.

Examples:

* Controllers handle HTTP requests.
* Services implement business logic.
* DTOs define API contracts.
* Entities represent domain models.
* Repositories/DbContext manage persistence.
* React components render UI.

---

# 3. SOLID Principles

The project attempts to follow the SOLID design principles.

### Single Responsibility Principle

Each class should have only one reason to change.

### Open/Closed Principle

New functionality should be added through extension rather than modifying existing code whenever possible.

### Liskov Substitution Principle

Implementations should be interchangeable through interfaces.

### Interface Segregation Principle

Interfaces expose only the operations required by consumers.

### Dependency Inversion Principle

High-level modules depend on abstractions instead of concrete implementations.

---

# 4. Dependency Injection

Services are resolved through ASP.NET Core's built-in Dependency Injection container.

Benefits include:

* Loose coupling
* Easier testing
* Better maintainability
* Flexible implementations

---

# 5. RESTful API Design

The backend follows REST conventions.

Examples:

* GET retrieves resources
* POST creates resources
* PUT updates resources
* DELETE removes resources

Resource names are plural.

Examples:

```
/api/books
/api/authors
/api/members
/api/loans
```

---

# 6. DTO-first Communication

The frontend never communicates directly with Entity Framework entities.

Instead:

```
Entity

↓

DTO

↓

API

↓

Frontend
```

This prevents over-posting, hides internal implementation details, and keeps APIs stable.

---

# 7. Thin Controllers

Controllers should contain little or no business logic.

Their responsibilities are limited to:

* Receiving requests
* Calling services
* Returning responses
* Handling HTTP status codes

Business rules belong in the Application or Infrastructure service layer.

---

# 8. Feature-Based Development

Development is organized by features rather than technical layers.

Examples:

* Authentication
* Dashboard
* Books
* Authors
* Members
* Loans
* Reservations

Each feature includes:

* Backend implementation
* Frontend implementation
* API integration
* UI
* Documentation

---

# 9. Incremental Development

Features are developed in small, independent increments.

Typical workflow:

```
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
```

This keeps pull requests focused and reduces merge conflicts.

---

# 10. Convention Over Configuration

The project follows established framework conventions whenever practical.

Examples include:

* ASP.NET Core routing
* Entity Framework Core conventions
* React project structure
* Material UI components

---

# 11. Code Readability

Readable code is preferred over clever code.

Guidelines include:

* Descriptive names
* Small methods
* Minimal nesting
* Consistent formatting
* Clear separation of logic

Code should be understandable without requiring extensive comments.

---

# 12. Reusability

Reusable components are preferred over duplicated implementations.

Examples:

* Shared lookup services
* Shared dialog components
* Shared API client
* Common DTO patterns

---

# 13. Consistent User Experience

UI behavior should remain consistent throughout the application.

Examples:

* Uniform list styling
* Consistent dialogs
* Common CRUD workflows
* Shared navigation
* Similar spacing and typography

---

# 14. Security First

Security considerations are incorporated from the beginning.

Current practices include:

* JWT Authentication
* ASP.NET Identity
* Role-based Authorization
* Password hashing
* Protected API endpoints

---

# 15. Fail Fast

Applications should detect invalid operations early and return meaningful errors.

Examples include:

* Member not found
* Book copy unavailable
* Invalid loan status
* Unauthorized access

Errors are handled centrally through middleware.

---

# 16. Single Source of Truth

Data should exist in only one authoritative location.

Examples:

* Book information stored in Books
* Author relationships stored in BookAuthors
* Loan status stored in Loans
* Copy availability stored in BookCopies

---

# 17. Keep Business Rules in the Backend

The frontend should focus on presentation.

Business decisions such as:

* Loan availability
* Reservation validity
* Copy status
* Due date calculation

are enforced on the server.

---

# 18. Progressive Enhancement

The project prioritizes core functionality first, followed by iterative improvements.

Typical progression:

1. Working API
2. Frontend integration
3. UI refinement
4. Validation
5. Documentation
6. Testing
7. Optimization

---

# 19. Documentation as Part of Development

Documentation evolves alongside the codebase.

Major additions should be accompanied by updates to:

* README
* Architecture documentation
* Project Plan
* Engineering Principles

---

# 20. Continuous Improvement

The codebase is expected to improve over time.

Examples include:

* Refactoring duplicated logic
* Improving UI consistency
* Reducing technical debt
* Expanding automated testing
* Enhancing performance

---

# Core Philosophy

This project values:

* Simplicity over complexity.
* Readability over cleverness.
* Maintainability over shortcuts.
* Incremental progress over large rewrites.
* Consistency across backend and frontend.
* Building software that remains understandable and extensible as it grows.
