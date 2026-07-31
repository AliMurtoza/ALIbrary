using ALIbrary.Application.Languages.DTOs;
using ALIbrary.Application.Languages.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLanguageRequest request)
    {
        return Ok(await _languageService.CreateAsync(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _languageService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var language = await _languageService.GetByIdAsync(id);

        if (language == null)
            return NotFound();

        return Ok(language);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateLanguageRequest request)
    {
        var language = await _languageService.UpdateAsync(id, request);

        if (language == null)
            return NotFound();

        return Ok(language);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _languageService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}