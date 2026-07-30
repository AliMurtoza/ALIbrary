using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class BookshelfBook : BaseEntity
{
    public Guid BookshelfId { get; set; }

    public Guid UserBookId { get; set; }

    public Bookshelf Bookshelf { get; set; } = null!;

    public UserBook UserBook { get; set; } = null!;
}