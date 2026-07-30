using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? CoverImageUrl { get; set; }

    public int PublicationYear { get; set; }

    public int PageCount { get; set; }

    public decimal AverageRating { get; set; }

    public int TotalRatings { get; set; }

    public Guid CategoryId { get; set; }

    public Guid PublisherId { get; set; }

    public Guid LanguageId { get; set; }

    public Category Category { get; set; } = null!;

    public Publisher Publisher { get; set; } = null!;

    public Language Language { get; set; } = null!;

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
}