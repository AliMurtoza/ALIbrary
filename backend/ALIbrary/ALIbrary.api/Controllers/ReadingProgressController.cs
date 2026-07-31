using ALIbrary.Application.ReadingProgress.DTOs;
using ALIbrary.Application.ReadingProgress.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ReadingProgressController : ControllerBase
{
    private readonly IReadingProgressService _readingProgressService;

    public ReadingProgressController(IReadingProgressService readingProgressService)
    {
        _readingProgressService = readingProgressService;
    }

    [HttpPost("{userBookId:guid}")]
    public async Task<IActionResult> Create(Guid userBookId)
    {
        return Ok(await _readingProgressService.CreateAsync(userBookId));
    }

    [HttpPut("{userBookId:guid}")]
    public async Task<IActionResult> Update(
        Guid userBookId,
        UpdateReadingProgressRequest request)
    {
        var progress = await _readingProgressService.UpdateAsync(userBookId, request);

        if (progress == null)
            return NotFound();

        return Ok(progress);
    }

    [HttpGet("{userBookId:guid}")]
    public async Task<IActionResult> Get(Guid userBookId)
    {
        var progress = await _readingProgressService.GetAsync(userBookId);

        if (progress == null)
            return NotFound();

        return Ok(progress);
    }
}