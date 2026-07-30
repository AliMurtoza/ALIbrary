using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class Member : BaseEntity
{
    public string UserId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();

    public ICollection<Bookshelf> Bookshelves { get; set; } = new List<Bookshelf>();
}