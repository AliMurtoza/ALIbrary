using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.Reservations.DTOs;

public class ReservationResponse
{
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    public DateTime ReservedAt { get; set; }

    public ReservationStatus Status { get; set; }
}