using ALIbrary.Application.Reservations.DTOs;

namespace ALIbrary.Application.Reservations.Interfaces;

public interface IReservationService
{
    Task<ReservationResponse> CreateAsync(CreateReservationRequest request);

    Task<ReservationResponse?> CancelAsync(Guid reservationId);

    Task<List<ReservationResponse>> GetAllAsync();

    Task<ReservationResponse?> GetByIdAsync(Guid id);
}