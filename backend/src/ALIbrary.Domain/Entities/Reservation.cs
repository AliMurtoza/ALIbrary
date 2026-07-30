using ALIbrary.Domain.Common;
using ALIbrary.Domain.Enums;

namespace ALIbrary.Domain.Entities;

public class Reservation : BaseEntity
{
    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }

    public DateTime ReservedAt { get; set; }

    public ReservationStatus Status { get; set; }

    public Member Member { get; set; } = null!;

    public Book Book { get; set; } = null!;
}