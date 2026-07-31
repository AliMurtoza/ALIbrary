using ALIbrary.Application.BookReviews.DTOs;
using ALIbrary.Application.BookReviews.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BookReviewsController : ControllerBase
{
    private readonly IBookReviewService _bookReviewService;

    public BookReviewsController(IBookReviewService bookReviewService)
    {
        _bookReviewService = bookReviewService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookReviewRequest request)
    {
        return Ok(await _bookReviewService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateBookReviewRequest request)
    {
        var review = await _bookReviewService.UpdateAsync(id, request);

        if (review == null)
            return NotFound();

        return Ok(review);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _bookReviewService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var review = await _bookReviewService.GetByIdAsync(id);

        if (review == null)
            return NotFound();

        return Ok(review);
    }
}