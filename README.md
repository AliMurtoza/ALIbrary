# ALIbrary 📚

> A modern Library Management System built with **ASP.NET Core**, **Entity Framework Core**, **PostgreSQL**, **React**, and **TypeScript**.

---

## Overview

ALIbrary is a full-stack Library Management System designed to demonstrate modern enterprise software engineering practices using the .NET ecosystem.

Rather than focusing only on CRUD operations, the project models real-world library workflows including authentication, book management, loans, reservations, inventory tracking, and dashboard analytics while following Clean Architecture principles.

The project is intended both as a portfolio project and as a practical reference implementation of a layered .NET application.

---

# Features

## Authentication

* JWT Authentication
* ASP.NET Core Identity
* Secure login
* Password hashing
* Role-based authorization
* Protected API endpoints

---

## Dashboard

A centralized dashboard displaying important library statistics.

Currently includes:

* Total Books
* Total Authors
* Active Loans
* Pending Reservations
* Recently Added Books

---

## Book Management

Complete book management module.

Features:

* View books
* Create books
* Edit books
* Delete books
* Category selection
* Publisher selection
* Language selection
* Responsive dialogs
* Confirmation dialog before deletion

Displayed information includes:

* Title
* ISBN
* Publication Year
* Category
* Publisher
* Language

---

## Author Management

Author management module.

Features:

* View authors
* Create authors
* Edit authors
* Delete authors
* Biography support
* Confirmation dialog

---

## Loan Management

Loan workflow implementation.

Current functionality:

* View active and returned loans
* Borrow book
* Return book
* Loan status
* Due dates
* Barcode display

---

## Reservation Management

Reservation module.

Current functionality:

* View reservations
* Cancel pending reservations
* Reservation status display

---

## Lookup Management

Reusable lookup APIs power dropdowns throughout the application.

Examples:

* Categories
* Languages
* Publishers

---

## Backend Architecture

The backend follows a layered architecture inspired by Clean Architecture.

```
API
│
├── Controllers
│
Application
│
├── DTOs
├── Interfaces
│
Infrastructure
│
├── Services
├── Data
├── Identity
├── Seed
│
Domain
│
├── Entities
├── Enums
├── Common
```

Responsibilities are clearly separated between:

* Domain
* Application
* Infrastructure
* Presentation

---

# Frontend Architecture

Built using React with TypeScript.

```
src
│
├── api
├── components
├── layouts
├── pages
│   ├── Dashboard
│   ├── Books
│   ├── Authors
│   ├── Loans
│   └── Reservations
│
├── routes
├── services
├── types
└── utils
```

The frontend communicates with the backend exclusively through service classes.

---

# Technology Stack

## Backend

* ASP.NET Core Web API
* C#
* Entity Framework Core
* PostgreSQL
* ASP.NET Core Identity
* JWT Authentication

---

## Frontend

* React
* TypeScript
* Vite
* Material UI
* Axios
* React Router

---

## Database

* PostgreSQL

---

## Authentication

* JWT Bearer Authentication
* ASP.NET Identity

---

## Development Tools

* Visual Studio 2022
* Visual Studio Code
* Postman
* Swagger
* Git
* GitHub

---

# Implemented Modules

| Module         | Status |
| -------------- | :----: |
| Authentication |    ✅   |
| Dashboard      |    ✅   |
| Books          |    ✅   |
| Authors        |    ✅   |
| Loans          |    ✅   |
| Reservations   |    ✅   |

---

# Domain Model

Current core entities include:

* User
* Member
* Book
* BookCopy
* Author
* Category
* Publisher
* Language
* Loan
* Reservation
* Review
* Fine
* Notification
* BookAuthor

---

# Current Workflows

## Book Workflow

```
Book
    ↓
Category
Publisher
Language
    ↓
CRUD
```

---

## Loan Workflow

```
Member
    ↓
Book Copy
    ↓
Borrow
    ↓
Return
```

---

## Reservation Workflow

```
Member
    ↓
Book
    ↓
Reserve
    ↓
Cancel
```

---

# Security

Implemented:

* JWT Authentication
* Identity
* Authorization
* Role-based endpoints
* Protected routes
* Token validation

---

# UI Highlights

* Material UI design
* Responsive layout
* Consistent card styling
* Dialog-based forms
* Confirmation dialogs
* Dashboard overview
* Left navigation drawer

---

# API Overview

Major API groups include:

```
/api/Auth
/api/Dashboard
/api/Books
/api/Authors
/api/Categories
/api/Publishers
/api/Languages
/api/Loans
/api/Reservations
```

---

# Running the Project

## Backend

```bash
cd ALIbrary.Api

dotnet restore

dotnet ef database update

dotnet run
```

Backend runs on:

```
https://localhost:7281
```

---

## Frontend

```bash
cd ALIbrary.Client

npm install

npm run dev
```

Frontend runs on:

```
http://localhost:5173
```

---

# Project Screens

Current pages:

* Login
* Dashboard
* Books
* Authors
* Loans
* Reservations

---

# Future Improvements

Planned enhancements include:

### Library Operations

* Connect Authors while creating books
* Book copy management
* Member management
* Fine management
* Reviews
* Notifications

### Dashboard

* Charts
* Monthly statistics
* Activity timeline

### Books

* Search
* Sorting
* Pagination
* Filtering

### Loans

* Overdue highlighting
* Renew loans
* Loan history

### Reservations

* Create reservation UI
* Fulfillment workflow

### UX

* Toast notifications
* Optimistic updates
* Loading skeletons
* Better validation

### Technical

* AutoMapper
* FluentValidation
* Global error handling improvements
* Unit tests
* Integration tests
* Docker support
* CI/CD pipeline

---

# Project Goals

This project aims to demonstrate:

* Clean Architecture
* Layered application design
* Enterprise backend development
* Modern React frontend development
* RESTful API design
* Authentication & Authorization
* Entity Framework Core
* Relational database modeling
* Professional UI implementation

---

# License

This project is intended for educational and portfolio purposes.

---

## Author

**Ali Murtoza Shihab**

* Full Stack Software Engineer
* B.Sc. in Computer Science & Engineering
* University of Dhaka

---

> ALIbrary is being developed incrementally using feature branches and pull requests, following a professional Git workflow where each module is implemented, reviewed, and merged independently.
