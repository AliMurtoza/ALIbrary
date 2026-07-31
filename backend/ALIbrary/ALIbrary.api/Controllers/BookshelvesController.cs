using ALIbrary.Application.Bookshelves.DTOs;
using ALIbrary.Application.Bookshelves.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BookshelvesController : ControllerBase
{
    private readonly IBookshelfService _bookshelfService;

    public BookshelvesController(IBookshelfService bookshelfService)
    {
        _bookshelfService = bookshelfService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookshelfRequest request)
    {
        return Ok(await _bookshelfService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateBookshelfRequest request)
    {
        var bookshelf = await _bookshelfService.UpdateAsync(id, request);

        if (bookshelf == null)
            return NotFound();

        return Ok(bookshelf);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _bookshelfService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var bookshelf = await _bookshelfService.GetByIdAsync(id);

        if (bookshelf == null)
            return NotFound();

        return Ok(bookshelf);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _bookshelfService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}