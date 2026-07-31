using ALIbrary.Application.Publishers.DTOs;
using ALIbrary.Application.Publishers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePublisherRequest request)
    {
        return Ok(await _publisherService.CreateAsync(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _publisherService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var publisher = await _publisherService.GetByIdAsync(id);

        if (publisher == null)
            return NotFound();

        return Ok(publisher);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdatePublisherRequest request)
    {
        var publisher = await _publisherService.UpdateAsync(id, request);

        if (publisher == null)
            return NotFound();

        return Ok(publisher);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _publisherService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}