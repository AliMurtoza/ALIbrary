# Development Log

This document records the daily development progress of **ALIbrary**.

---

# 28 July 2026 (Day 1)

## Project Foundation

* Initialized backend using ASP.NET Core Web API.
* Initialized frontend using React + TypeScript + Vite.
* Configured Entity Framework Core with SQL Server.
* Established Clean Architecture solution structure.
* Configured dependency injection.
* Added Swagger/OpenAPI.
* Implemented global exception handling middleware.
* Configured JWT Authentication.
* Integrated ASP.NET Identity.
* Implemented role-based authorization.
* Added role seeding (Admin & Member).
* Added default administrator account seeding.

---

# 29 July 2026 (Day 2)

## Dashboard & Book Management

Implemented Dashboard.

Completed:

* Dashboard statistics
* Total Books
* Total Authors
* Active Loans
* Pending Reservations
* Recently Added Books
* Responsive dashboard UI

Implemented complete Book Management.

Backend:

* CRUD operations
* Search & filtering
* DTO mapping

Frontend:

* Book list
* Add/Edit/Delete dialogs
* Category lookup
* Publisher lookup
* Language lookup
* Consistent Material UI design

---

# 30 July 2026 (Day 3)

## Author, Loan & Reservation Management

Completed Author Management.

* CRUD API
* CRUD UI
* Responsive author page

Completed Loan Management.

Backend:

* Borrow book
* Return book
* Loan history

Frontend:

* Loan list
* Borrow dialog
* Return dialog
* Status indicators

Completed Reservation Management.

Backend:

* Create reservation
* Cancel reservation
* Reservation listing

Frontend:

* Reservation page
* Create reservation dialog
* Cancel reservation
* Status chips

---

# 31 July 2026 (Day 4)

## Member Management & Book Improvements

Completed Member Management.

Backend:

* CRUD endpoints
* Service layer

Frontend:

* Member list
* Add/Edit/Delete dialogs

Enhanced Book Management.

* Added multi-author support.
* Connected books with authors.
* Displayed author names in the Books page.
* Added author multi-select while creating/editing books.

Improved UI consistency across:

* Dashboard
* Books
* Authors
* Members
* Loans
* Reservations

---

# 1 August 2026 (Day 5)

## Security, Documentation & Final Polish

Security improvements:

* Automatic Admin role assignment.
* Default administrator seeding.
* Removed manual database role updates.

Documentation completed:

* README
* System Design
* Project Plan
* Engineering Principles
* Architecture Decisions
* Entity Relationship Diagram (ERD)
* Changelog
* Development Log

Repository improvements:

* Added GitHub project documentation.
* Improved repository metadata.
* Organized architecture and development documentation.

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
| Documentation     | ✅ Complete |
| Branch Management | ⏳ Pending  |
| Reports           | ⏳ Pending  |
| Unit Tests        | ⏳ Pending  |
| Docker / CI-CD    | ⏳ Pending  |
