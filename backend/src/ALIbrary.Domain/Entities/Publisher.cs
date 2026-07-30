using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}