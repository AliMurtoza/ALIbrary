using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class Author : BaseEntity
{
    public string DisplayName { get; set; } = string.Empty;

    public string? Biography { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}