using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class Language : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}