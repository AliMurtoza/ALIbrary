using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class Bookshelf : BaseEntity
{
    public Guid MemberId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Member Member { get; set; } = null!;

    public ICollection<BookshelfBook> BookshelfBooks { get; set; } = new List<BookshelfBook>();
}