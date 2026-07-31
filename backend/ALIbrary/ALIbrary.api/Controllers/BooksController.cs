using ALIbrary.Application.Books.DTOs;
using ALIbrary.Application.Books.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request)
    {
        return Ok(await _bookService.CreateAsync(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] BookQueryParameters query)
    {
        return Ok(await _bookService.GetAllAsync(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var book = await _bookService.GetByIdAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateBookRequest request)
    {
        var book = await _bookService.UpdateAsync(id, request);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _bookService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}