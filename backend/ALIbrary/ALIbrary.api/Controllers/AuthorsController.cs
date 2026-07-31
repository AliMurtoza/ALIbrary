using ALIbrary.Application.Authors.DTOs;
using ALIbrary.Application.Authors.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorRequest request)
    {
        return Ok(await _authorService.CreateAsync(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _authorService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var author = await _authorService.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        return Ok(author);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateAuthorRequest request)
    {
        var author = await _authorService.UpdateAsync(id, request);

        if (author == null)
            return NotFound();

        return Ok(author);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _authorService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}