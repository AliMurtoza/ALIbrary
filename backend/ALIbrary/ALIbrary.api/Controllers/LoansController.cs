using ALIbrary.Application.Loans.DTOs;
using ALIbrary.Application.Loans.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpPost("borrow")]
    public async Task<IActionResult> Borrow(BorrowBookRequest request)
    {
        return Ok(await _loanService.BorrowAsync(request));
    }

    [HttpPost("{loanId:guid}/return")]
    public async Task<IActionResult> Return(Guid loanId)
    {
        var loan = await _loanService.ReturnAsync(loanId);

        if (loan == null)
            return NotFound();

        return Ok(loan);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _loanService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var loan = await _loanService.GetByIdAsync(id);

        if (loan == null)
            return NotFound();

        return Ok(loan);
    }
}