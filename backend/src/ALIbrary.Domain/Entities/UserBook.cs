using ALIbrary.Domain.Common;
using ALIbrary.Domain.Enums;

namespace ALIbrary.Domain.Entities;

public class UserBook : BaseEntity
{
    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }

    public ReadingStatus ReadingStatus { get; set; }

    public bool IsFavorite { get; set; }

    public Member Member { get; set; } = null!;

    public Book Book { get; set; } = null!;

    public ReadingProgress ReadingProgress { get; set; } = null!;

    public BookReview? BookReview { get; set; }

    public ICollection<BookshelfBook> BookshelfBooks { get; set; } = new List<BookshelfBook>();
}