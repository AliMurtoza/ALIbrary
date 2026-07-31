using ALIbrary.Application.UserBooks.DTOs;
using ALIbrary.Application.UserBooks.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserBooksController : ControllerBase
{
    private readonly IUserBookService _userBookService;

    public UserBooksController(IUserBookService userBookService)
    {
        _userBookService = userBookService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserBookRequest request)
    {
        return Ok(await _userBookService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserBookRequest request)
    {
        var userBook = await _userBookService.UpdateAsync(id, request);

        if (userBook == null)
            return NotFound();

        return Ok(userBook);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userBookService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var userBook = await _userBookService.GetByIdAsync(id);

        if (userBook == null)
            return NotFound();

        return Ok(userBook);
    }
}