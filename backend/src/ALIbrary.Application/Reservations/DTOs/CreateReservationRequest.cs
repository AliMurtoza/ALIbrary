namespace ALIbrary.Application.Reservations.DTOs;

public class CreateReservationRequest
{
    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }
}