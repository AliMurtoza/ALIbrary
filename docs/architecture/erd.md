# Entity Relationship Diagram (ERD)

## Purpose

This document defines the complete database domain model for ALIbrary.

It serves as the primary reference for designing entities, relationships, database constraints, and business rules before implementation.

---

# Domain Overview

The system is divided into two primary domains:

## Library Domain

Represents assets owned and managed by the library.

- Books
- Physical Book Copies
- Authors
- Publishers
- Categories
- Languages
- Loans
- Reservations

---

## User Domain

Represents a member's personal interaction with books.

- UserBook
- ReadingProgress
- BookReview
- Bookshelf
- BookshelfBook

---

# High-Level ER Diagram

```text
                           ApplicationUser
                                  │
                                  │ 1:1
                                  ▼
                               Member
                                  │
             ┌────────────────────┼────────────────────┐
             │                    │                    │
             │                    │                    │
             ▼                    ▼                    ▼
           Loan             Reservation           UserBook
             │                    │                    │
             │                    │                    ├──────────────┐
             │                    │                    │              │
             ▼                    │                    ▼              ▼
         BookCopy                 │           ReadingProgress    BookReview
             │                    │
             │                    │
             ▼                    ▼
                           Book
            ┌──────────────┼──────────────┬──────────────┐
            │              │              │              │
            ▼              ▼              ▼              ▼
         Category      Publisher      Language       BookAuthor
                                                          │
                                                          ▼
                                                       Author

Member
   │
   ▼
Bookshelf
   │
   ▼
BookshelfBook
   │
   ▼
UserBook
```

---

# Entity Summary

| Entity | Description |
|---------|-------------|
| ApplicationUser | ASP.NET Identity user |
| Member | Library member profile |
| Book | Logical book information |
| BookCopy | Physical copy owned by the library |
| Author | Book author |
| BookAuthor | Many-to-many relationship between books and authors |
| Publisher | Book publisher |
| Category | Book category |
| Language | Book language |
| Loan | Borrowing records |
| Reservation | Book reservations |
| UserBook | A member's personal relationship with a book |
| ReadingProgress | Tracks reading progress |
| BookReview | Book ratings and reviews |
| Bookshelf | User-created collection |
| BookshelfBook | Books assigned to a bookshelf |

---

# Relationships

## Authentication

ApplicationUser (1) ─────── (1) Member

---

## Library

Category (1) ─────── (*) Book

Publisher (1) ─────── (*) Book

Language (1) ─────── (*) Book

Book (1) ─────── (*) BookCopy

Book (*) ─────── (*) Author

(BookAuthor)

---

## Circulation

Member (1) ─────── (*) Loan

BookCopy (1) ─────── (*) Loan

Member (1) ─────── (*) Reservation

Book (1) ─────── (*) Reservation

---

## User Domain

Member (1) ─────── (*) UserBook

Book (1) ─────── (*) UserBook

UserBook (1) ─────── (1) ReadingProgress

UserBook (1) ─────── (0..1) BookReview

Member (1) ─────── (*) Bookshelf

Bookshelf (1) ─────── (*) BookshelfBook

UserBook (1) ─────── (*) BookshelfBook

---

# Enumerations

## BookCopyStatus

- Available
- Borrowed
- Reserved
- Lost
- Maintenance

---

## LoanStatus

- Active
- Returned
- Overdue

---

## ReservationStatus

- Pending
- Fulfilled
- Cancelled
- Expired

---

## ReadingStatus

- WantToRead
- Reading
- Completed
- Abandoned

---

# Business Rules

- Every Book must belong to one Category.
- Every Book must belong to one Publisher.
- Every Book must belong to one Language.
- A Book may have one or more Authors.
- A Book may have multiple physical BookCopies.
- Members borrow BookCopies, not Books.
- Members reserve Books, not BookCopies.
- Every UserBook belongs to exactly one Member and one Book.
- Every UserBook has exactly one ReadingProgress record.
- A UserBook may have at most one BookReview.
- A Member may create multiple Bookshelves.
- A UserBook may belong to multiple Bookshelves.

---

# Database Constraints

## Unique

- ISBN
- Barcode
- (UserBookId) in BookReview

---

# Notes

The domain model has been finalized before implementation.

Future enhancements should not introduce new entities unless:

- Required by business requirements.
- Required by project requirements.
- Required to resolve an architectural limitation.

All future schema changes should be reflected in this document before implementation.