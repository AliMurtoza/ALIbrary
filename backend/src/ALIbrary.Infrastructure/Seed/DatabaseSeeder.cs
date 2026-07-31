using ALIbrary.Domain.Entities;
using ALIbrary.Domain.Enums;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Languages
        if (!await context.Languages.AnyAsync())
        {
            context.Languages.AddRange(
                new Language { Name = "English", Code = "en" },
                new Language { Name = "Bangla", Code = "bn" },
                new Language { Name = "Japanese", Code = "ja" },
                new Language { Name = "German", Code = "de" },
                new Language { Name = "French", Code = "fr" }
            );
        }

        // Publishers
        if (!await context.Publishers.AnyAsync())
        {
            context.Publishers.AddRange(
                new Publisher { Name = "O'Reilly Media" },
                new Publisher { Name = "Manning" },
                new Publisher { Name = "Packt" },
                new Publisher { Name = "Apress" },
                new Publisher { Name = "Pearson" },
                new Publisher { Name = "No Starch Press" },
                new Publisher { Name = "Addison-Wesley" },
                new Publisher { Name = "Pragmatic Bookshelf" },
                new Publisher { Name = "Wiley" },
                new Publisher { Name = "McGraw-Hill" }
            );
        }

        // Categories
        if (!await context.Categories.AnyAsync())
        {
            context.Categories.AddRange(
                new Category { Name = "Programming" },
                new Category { Name = "Software Engineering" },
                new Category { Name = "Artificial Intelligence" },
                new Category { Name = "Algorithms" },
                new Category { Name = "Databases" },
                new Category { Name = "Networking" },
                new Category { Name = "Operating Systems" },
                new Category { Name = "Cybersecurity" },
                new Category { Name = "Fiction" },
                new Category { Name = "History" }
            );
        }

        // Authors
        if (!await context.Authors.AnyAsync())
        {
            context.Authors.AddRange(
                new Author { DisplayName = "Robert C. Martin" },
                new Author { DisplayName = "Martin Fowler" },
                new Author { DisplayName = "Erich Gamma" },
                new Author { DisplayName = "Andrew Hunt" },
                new Author { DisplayName = "David Thomas" },
                new Author { DisplayName = "Jon Skeet" },
                new Author { DisplayName = "Jeffrey Richter" },
                new Author { DisplayName = "Donald Knuth" },
                new Author { DisplayName = "Thomas H. Cormen" },
                new Author { DisplayName = "Andrew S. Tanenbaum" },
                new Author { DisplayName = "Robert Sedgewick" },
                new Author { DisplayName = "Ian Sommerville" }
            );
        }

        // Books
        if (!await context.Books.AnyAsync())
        {
            var publisher = await context.Publishers.FirstAsync();
            var language = await context.Languages.FirstAsync();
            var category = await context.Categories.FirstAsync();

            context.Books.AddRange(

                new Book
                {
                    Title = "Clean Code",
                    ISBN = "9780132350884",
                    Description = "A Handbook of Agile Software Craftsmanship",
                    PublicationYear = 2008,
                    PublisherId = publisher.Id,
                    LanguageId = language.Id,
                    CategoryId = category.Id,
                    PageCount = 464,
                    AverageRating = 4.8m,
                    TotalRatings = 1200
                },

                new Book
                {
                    Title = "Clean Architecture",
                    ISBN = "9780134494166",
                    Description = "Guide to Software Architecture",
                    PublicationYear = 2017,
                    PublisherId = publisher.Id,
                    LanguageId = language.Id,
                    CategoryId = category.Id,
                    PageCount = 432,
                    AverageRating = 4.7m,
                    TotalRatings = 980
                },

                new Book
                {
                    Title = "The Pragmatic Programmer",
                    ISBN = "9780135957059",
                    Description = "Classic software engineering book",
                    PublicationYear = 2019,
                    PublisherId = publisher.Id,
                    LanguageId = language.Id,
                    CategoryId = category.Id,
                    PageCount = 352,
                    AverageRating = 4.9m,
                    TotalRatings = 1600
                },

                new Book
                {
                    Title = "Design Patterns",
                    ISBN = "9780201633610",
                    Description = "Gang of Four",
                    PublicationYear = 1994,
                    PublisherId = publisher.Id,
                    LanguageId = language.Id,
                    CategoryId = category.Id,
                    PageCount = 395,
                    AverageRating = 4.8m,
                    TotalRatings = 1400
                },

                new Book
                {
                    Title = "Refactoring",
                    ISBN = "9780134757599",
                    Description = "Improving Existing Code",
                    PublicationYear = 2018,
                    PublisherId = publisher.Id,
                    LanguageId = language.Id,
                    CategoryId = category.Id,
                    PageCount = 448,
                    AverageRating = 4.8m,
                    TotalRatings = 900
                }

            );

            await context.SaveChangesAsync();
        }

        // Book Copies
        if (!await context.BookCopies.AnyAsync())
        {
            var books = await context.Books.ToListAsync();

            int barcode = 1;

            foreach (var book in books)
            {
                for (int i = 1; i <= 3; i++)
                {
                    context.BookCopies.Add(
                        new BookCopy
                        {
                            BookId = book.Id,
                            Barcode = $"BC{barcode:D6}",
                            ShelfLocation = $"A-{barcode:D2}",
                            Condition = Domain.Enums.BookCopyCondition.Good,
                            Status = Domain.Enums.BookCopyStatus.Available
                        });

                    barcode++;
                }
            }

            await context.SaveChangesAsync();
        }

        // Members
        if (!await context.Members.AnyAsync())
        {
            context.Members.AddRange(

                new Member
                {
                    UserId = Guid.NewGuid().ToString(),
                    FirstName = "Alice",
                    LastName = "Johnson"
                },

                new Member
                {
                    UserId = Guid.NewGuid().ToString(),
                    FirstName = "Bob",
                    LastName = "Smith"
                },

                new Member
                {
                    UserId = Guid.NewGuid().ToString(),
                    FirstName = "Charlie",
                    LastName = "Brown"
                },

                new Member
                {
                    UserId = Guid.NewGuid().ToString(),
                    FirstName = "David",
                    LastName = "Wilson"
                },

                new Member
                {
                    UserId = Guid.NewGuid().ToString(),
                    FirstName = "Eva",
                    LastName = "Green"
                }

            );

            await context.SaveChangesAsync();
        }
        // Loans
        if (!await context.Loans.AnyAsync())
        {
            var members = await context.Members.ToListAsync();
            var copies = await context.BookCopies.ToListAsync();

            context.Loans.AddRange(

                new Loan
                {
                    MemberId = members[0].Id,
                    BookCopyId = copies[0].Id,
                    BorrowedAt = DateTime.UtcNow.AddDays(-5),
                    DueAt = DateTime.UtcNow.AddDays(10),
                    Status = Domain.Enums.LoanStatus.Active
                },

                new Loan
                {
                    MemberId = members[1].Id,
                    BookCopyId = copies[1].Id,
                    BorrowedAt = DateTime.UtcNow.AddDays(-12),
                    DueAt = DateTime.UtcNow.AddDays(2),
                    Status = Domain.Enums.LoanStatus.Active
                }

            );

            copies[0].Status = Domain.Enums.BookCopyStatus.Borrowed;
            copies[1].Status = Domain.Enums.BookCopyStatus.Borrowed;

            await context.SaveChangesAsync();
        }

        // Reservations
        if (!await context.Reservations.AnyAsync())
        {
            var members = await context.Members.ToListAsync();
            var books = await context.Books.ToListAsync();

            if (members.Count >= 2 && books.Count >= 2)
            {
                context.Reservations.AddRange(

                    new Reservation
                    {
                        MemberId = members[0].Id,
                        BookId = books[0].Id,
                        ReservedAt = DateTime.UtcNow.AddDays(-1),
                        Status = ReservationStatus.Pending
                    },

                    new Reservation
                    {
                        MemberId = members[1].Id,
                        BookId = books[1].Id,
                        ReservedAt = DateTime.UtcNow,
                        Status = ReservationStatus.Pending
                    }

                );

                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }

        // User books
        if (!await context.UserBooks.AnyAsync())
        {
            var members = await context.Members.ToListAsync();
            var books = await context.Books.ToListAsync();

            context.UserBooks.AddRange(

                new UserBook
                {
                    MemberId = members[0].Id,
                    BookId = books[0].Id,
                    ReadingStatus = Domain.Enums.ReadingStatus.Reading,
                    IsFavorite = true
                },

                new UserBook
                {
                    MemberId = members[1].Id,
                    BookId = books[1].Id,
                    ReadingStatus = Domain.Enums.ReadingStatus.Completed,
                    IsFavorite = false
                }

            );

            await context.SaveChangesAsync();
        }

        // Reading progress
        if (!await context.ReadingProgress.AnyAsync())
        {
            var userBooks = await context.UserBooks.ToListAsync();

            context.ReadingProgress.AddRange(

                new ReadingProgress
                {
                    UserBookId = userBooks[0].Id,
                    CurrentPage = 123,
                    StartedReadingAt = DateTime.UtcNow.AddDays(-4),
                    LastUpdatedAt = DateTime.UtcNow
                },

                new ReadingProgress
                {
                    UserBookId = userBooks[1].Id,
                    CurrentPage = 432,
                    StartedReadingAt = DateTime.UtcNow.AddDays(-20),
                    FinishedReadingAt = DateTime.UtcNow.AddDays(-2),
                    LastUpdatedAt = DateTime.UtcNow.AddDays(-2)
                }

            );

            await context.SaveChangesAsync();
        }

        // Book reviews
        if (!await context.BookReviews.AnyAsync())
        {
            var userBooks = await context.UserBooks.ToListAsync();

            context.BookReviews.Add(

                new BookReview
                {
                    UserBookId = userBooks[1].Id,
                    Rating = 5,
                    Title = "Excellent",
                    Review = "Must read for every software engineer."
                }

            );

            await context.SaveChangesAsync();
        }

        // Book shelves
        if (!await context.Bookshelves.AnyAsync())
        {
            var members = await context.Members.ToListAsync();

            context.Bookshelves.Add(

                new Bookshelf
                {
                    MemberId = members[0].Id,
                    Name = "Favorites",
                    Description = "My favorite programming books."
                }

            );

            await context.SaveChangesAsync();
        }

        // Bookshelf books
        if (!await context.BookshelfBooks.AnyAsync())
        {
            var shelf = await context.Bookshelves.FirstAsync();
            var userBook = await context.UserBooks.FirstAsync();

            context.BookshelfBooks.Add(

                new BookshelfBook
                {
                    BookshelfId = shelf.Id,
                    UserBookId = userBook.Id
                }

            );

            await context.SaveChangesAsync();
        }

        // Book authors
        if (!await context.BookAuthors.AnyAsync())
        {
            var books = await context.Books.OrderBy(b => b.Title).ToListAsync();
            var authors = await context.Authors.OrderBy(a => a.DisplayName).ToListAsync();

            if (books.Count >= 5 && authors.Count >= 5)
            {
                context.BookAuthors.AddRange(

                    new BookAuthor
                    {
                        BookId = books.First(b => b.Title == "Clean Code").Id,
                        AuthorId = authors.First(a => a.DisplayName == "Robert C. Martin").Id
                    },

                    new BookAuthor
                    {
                        BookId = books.First(b => b.Title == "Clean Architecture").Id,
                        AuthorId = authors.First(a => a.DisplayName == "Robert C. Martin").Id
                    },

                    new BookAuthor
                    {
                        BookId = books.First(b => b.Title == "Design Patterns").Id,
                        AuthorId = authors.First(a => a.DisplayName == "Erich Gamma").Id
                    },

                    new BookAuthor
                    {
                        BookId = books.First(b => b.Title == "Refactoring").Id,
                        AuthorId = authors.First(a => a.DisplayName == "Martin Fowler").Id
                    },

                    new BookAuthor
                    {
                        BookId = books.First(b => b.Title == "The Pragmatic Programmer").Id,
                        AuthorId = authors.First(a => a.DisplayName == "Andrew Hunt").Id
                    }

                );

                await context.SaveChangesAsync();
            }
        }

        await context.SaveChangesAsync();
    }
}