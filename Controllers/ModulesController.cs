using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.DTOs.Modules.Requests;
using IsiGatewayProcess.Filters;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/modules")]
//[JWTAuth]
public class ModulesController : ControllerBase
{
    private readonly IModuleService _service;

    public ModulesController(IModuleService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateModuleRequest request)
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
        PagedResult<ModuleDto> result = await _service.ListAsync(page, pageSize);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateModuleRequest request)
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
