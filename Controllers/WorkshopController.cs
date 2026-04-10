using IsiGatewayProcess.Filters;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/workshop")]
[JWTAuth]
public class WorkshopController : ControllerBase
{
    private readonly IWorkshopReadService _workshopReadService;

    public WorkshopController(IWorkshopReadService workshopReadService)
    {
        _workshopReadService = workshopReadService;
    }

    [HttpGet("lookups")]
    public async Task<IActionResult> GetLookups() => Ok(await _workshopReadService.GetLookupsAsync());

    [HttpGet("bootstrap")]
    public async Task<IActionResult> GetBootstrap() => Ok(await _workshopReadService.GetBootstrapAsync());

    [HttpGet("catalogue")]
    public async Task<IActionResult> GetCatalogue([FromQuery] Guid? itemId = null, [FromQuery] Guid? catalogueId = null) => Ok(await _workshopReadService.GetCatalogueAsync(itemId, catalogueId));

    [HttpGet("inventory")]
    public async Task<IActionResult> GetInventory([FromQuery] Guid? storageId = null, [FromQuery] Guid? itemId = null, [FromQuery] Guid? catalogueId = null) => Ok(await _workshopReadService.GetInventoryAsync(storageId, itemId, catalogueId));

    [HttpGet("petitions")]
    public async Task<IActionResult> GetPetitions([FromQuery] string? statusCode = null, [FromQuery] Guid? petitionaryOrganizationId = null, [FromQuery] Guid? receiverOrganizationId = null) => Ok(await _workshopReadService.GetPetitionsAsync(statusCode, petitionaryOrganizationId, receiverOrganizationId));

    [HttpGet("audit")]
    public async Task<IActionResult> GetAudit() => Ok(await _workshopReadService.GetAuditAsync());
}
