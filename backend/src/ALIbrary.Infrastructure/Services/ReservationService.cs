using ALIbrary.Application.Reservations.DTOs;
using ALIbrary.Application.Reservations.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Domain.Enums;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class ReservationService : IReservationService
{
    private readonly ApplicationDbContext _context;

    public ReservationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReservationResponse> CreateAsync(CreateReservationRequest request)
    {
        var member = await _context.Members.FindAsync(request.MemberId);

        if (member == null)
            throw new Exception("Member not found.");

        var book = await _context.Books.FindAsync(request.BookId);

        if (book == null)
            throw new Exception("Book not found.");

        var reservation = new Reservation
        {
            MemberId = request.MemberId,
            BookId = request.BookId,
            ReservedAt = DateTime.UtcNow,
            Status = ReservationStatus.Pending
        };

        _context.Reservations.Add(reservation);

        await _context.SaveChangesAsync();

        return new ReservationResponse
        {
            Id = reservation.Id,
            MemberId = reservation.MemberId,
            BookId = reservation.BookId,
            BookTitle = book.Title,
            ReservedAt = reservation.ReservedAt,
            Status = reservation.Status
        };
    }

    public async Task<ReservationResponse?> CancelAsync(Guid reservationId)
    {
        var reservation = await _context.Reservations
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Id == reservationId);

        if (reservation == null)
            return null;

        if (reservation.Status != ReservationStatus.Pending)
            throw new Exception("Only pending reservations can be cancelled.");

        reservation.Status = ReservationStatus.Cancelled;

        await _context.SaveChangesAsync();

        return new ReservationResponse
        {
            Id = reservation.Id,
            MemberId = reservation.MemberId,
            BookId = reservation.BookId,
            BookTitle = reservation.Book.Title,
            ReservedAt = reservation.ReservedAt,
            Status = reservation.Status
        };
    }

    public async Task<List<ReservationResponse>> GetAllAsync()
    {
        return await _context.Reservations
            .Include(r => r.Book)
            .Select(r => new ReservationResponse
            {
                Id = r.Id,
                MemberId = r.MemberId,
                BookId = r.BookId,
                BookTitle = r.Book.Title,
                ReservedAt = r.ReservedAt,
                Status = r.Status
            })
            .ToListAsync();
    }

    public async Task<ReservationResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Reservations
            .Include(r => r.Book)
            .Where(r => r.Id == id)
            .Select(r => new ReservationResponse
            {
                Id = r.Id,
                MemberId = r.MemberId,
                BookId = r.BookId,
                BookTitle = r.Book.Title,
                ReservedAt = r.ReservedAt,
                Status = r.Status
            })
            .FirstOrDefaultAsync();
    }
}