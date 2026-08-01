using ALIbrary.Application.Members.DTOs;
using ALIbrary.Application.Members.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALIbrary.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMemberRequest request)
    {
        return Ok(await _memberService.CreateAsync(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _memberService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var member = await _memberService.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        return Ok(member);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateMemberRequest request)
    {
        var member = await _memberService.UpdateAsync(id, request);

        if (member == null)
            return NotFound();

        return Ok(member);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _memberService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}