using ALIbrary.Application.BookCopies.DTOs;
using ALIbrary.Application.BookCopies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BookCopiesController : ControllerBase
{
    private readonly IBookCopyService _service;

    public BookCopiesController(IBookCopyService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCopyRequest request)
    {
        return Ok(await _service.CreateAsync(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var copy = await _service.GetByIdAsync(id);

        if (copy == null)
            return NotFound();

        return Ok(copy);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateBookCopyRequest request)
    {
        var copy = await _service.UpdateAsync(id, request);

        if (copy == null)
            return NotFound();

        return Ok(copy);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}