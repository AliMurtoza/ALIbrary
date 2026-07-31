using ALIbrary.Application.Reservations.DTOs;
using ALIbrary.Application.Reservations.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationRequest request)
    {
        return Ok(await _reservationService.CreateAsync(request));
    }

    [HttpPost("{reservationId:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid reservationId)
    {
        var reservation = await _reservationService.CancelAsync(reservationId);

        if (reservation == null)
            return NotFound();

        return Ok(reservation);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _reservationService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);

        if (reservation == null)
            return NotFound();

        return Ok(reservation);
    }
}