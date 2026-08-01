# Entity Relationship Diagram (ERD)

This document describes the current database structure of **ALIbrary**.

The system is implemented using **Entity Framework Core** with SQL Server.

---

# Entity Relationship Diagram

```mermaid
erDiagram

    ApplicationUser ||--o| Member : owns

    Member ||--o{ Loan : borrows
    Member ||--o{ Reservation : reserves
    Member ||--o{ Bookshelf : owns
    Member ||--o{ UserBook : reads

    Book ||--o{ BookCopy : has
    Book ||--o{ BookAuthor : written_by
    Author ||--o{ BookAuthor : writes

    Book ||--o{ Reservation : reserved

    BookCopy ||--o{ Loan : loaned

    Publisher ||--o{ Book : publishes
    Category ||--o{ Book : categorizes
    Language ||--o{ Book : written_in

    Book {
        Guid Id
        string Title
        string ISBN
        int PublicationYear
        string Description
        Guid CategoryId
        Guid PublisherId
        Guid LanguageId
    }

    Author {
        Guid Id
        string DisplayName
        string Biography
    }

    BookAuthor {
        Guid BookId
        Guid AuthorId
    }

    BookCopy {
        Guid Id
        Guid BookId
        string Barcode
        BookCopyStatus Status
    }

    Member {
        Guid Id
        string UserId
        string FirstName
        string LastName
    }

    Loan {
        Guid Id
        Guid MemberId
        Guid BookCopyId
        datetime BorrowedAt
        datetime DueAt
        datetime ReturnedAt
        LoanStatus Status
    }

    Reservation {
        Guid Id
        Guid MemberId
        Guid BookId
        datetime ReservedAt
        ReservationStatus Status
    }

    Publisher {
        Guid Id
        string Name
    }

    Category {
        Guid Id
        string Name
    }

    Language {
        Guid Id
        string Name
    }

    Bookshelf {
        Guid Id
        Guid MemberId
        string Name
    }

    UserBook {
        Guid Id
        Guid MemberId
        Guid BookId
        UserBookStatus Status
    }

    ApplicationUser {
        string Id
        string Email
    }
```

---

# Relationship Summary

| Relationship          | Cardinality               |
| --------------------- | ------------------------- |
| Publisher → Books     | One-to-Many               |
| Category → Books      | One-to-Many               |
| Language → Books      | One-to-Many               |
| Book → BookCopies     | One-to-Many               |
| Book ↔ Authors        | Many-to-Many (BookAuthor) |
| Member → Loans        | One-to-Many               |
| BookCopy → Loans      | One-to-Many               |
| Member → Reservations | One-to-Many               |
| Book → Reservations   | One-to-Many               |
| Member → Bookshelves  | One-to-Many               |
| Member → UserBooks    | One-to-Many               |

---

# Design Notes

* **Book** represents a bibliographic record, not a physical copy.
* **BookCopy** represents individual physical copies available for borrowing.
* **BookAuthor** implements the many-to-many relationship between books and authors.
* **Loan** references a **BookCopy**, allowing multiple copies of the same title to be borrowed independently.
* **Reservation** targets a **Book** rather than a specific copy, allowing the system to assign the next available copy in future implementations.
* **Member** extends an authenticated **ApplicationUser**, separating identity management from library-specific information.
* Lookup entities (**Category**, **Publisher**, and **Language**) normalize shared metadata and avoid duplication.

---

# Current Status

Implemented entities:

* ✅ ApplicationUser
* ✅ Member
* ✅ Book
* ✅ Author
* ✅ BookAuthor
* ✅ BookCopy
* ✅ Loan
* ✅ Reservation
* ✅ Publisher
* ✅ Category
* ✅ Language
* ✅ Bookshelf
* ✅ UserBook

The schema is designed to support future enhancements such as reporting, inventory tracking, overdue processing, and automated reservation fulfillment without major structural changes.
