using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();

    public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();

    public DbSet<BookCopy> BookCopies => Set<BookCopy>();

    public DbSet<BookReview> BookReviews => Set<BookReview>();

    public DbSet<Bookshelf> Bookshelves => Set<Bookshelf>();

    public DbSet<BookshelfBook> BookshelfBooks => Set<BookshelfBook>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Language> Languages => Set<Language>();

    public DbSet<Loan> Loans => Set<Loan>();

    public DbSet<Member> Members => Set<Member>();

    public DbSet<Publisher> Publishers => Set<Publisher>();

    public DbSet<ReadingProgress> ReadingProgress => Set<ReadingProgress>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<UserBook> UserBooks => Set<UserBook>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}