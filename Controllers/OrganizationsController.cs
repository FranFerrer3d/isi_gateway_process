using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.DTOs.Organizations.Requests;
using IsiGatewayProcess.Filters;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/organizations")]
[JWTAuth]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _service;

    public OrganizationsController(IOrganizationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrganizationRequest request)
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
        PagedResult<OrganizationDto> result = await _service.ListAsync(page, pageSize);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateOrganizationRequest request)
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
        var result = await _service.DeleteAsync(id);
        return result switch
        {
            OrganizationDeleteResult.Deleted => NoContent(),
            OrganizationDeleteResult.Conflict => Conflict("Organization has related entities."),
            _ => NotFound(),
        };
    }
}
