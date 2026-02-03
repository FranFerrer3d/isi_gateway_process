using IsiGatewayProcess.DTOs.Actions;
using IsiGatewayProcess.DTOs.Actions.Requests;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.Filters;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/actions")]
[JWTAuth]
public class ActionsController : ControllerBase
{
    private readonly IActionService _service;

    public ActionsController(IActionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateActionRequest request)
    {
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetAsync(id);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
    {
        PagedResult<ActionDto> result = await _service.ListAsync(page, pageSize);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateActionRequest request)
    {
        var result = await _service.UpdateAsync(id, request);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
