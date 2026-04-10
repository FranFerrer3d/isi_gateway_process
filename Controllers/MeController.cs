using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IsiGatewayProcess.Filters;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/me")]
[JWTAuth]
public class MeController : ControllerBase
{
    private readonly IPermissionService _permissionService;
    private readonly IWorkshopReadService _workshopReadService;

    public MeController(IPermissionService permissionService, IWorkshopReadService workshopReadService)
    {
        _permissionService = permissionService;
        _workshopReadService = workshopReadService;
    }

    [HttpGet("permissions")]
    public async Task<IActionResult> GetPermissions()
    {
        if (!TryGetUserId(out var userId))
        {
            return Unauthorized();
        }

        var permissions = await _permissionService.GetPermissionsForUserAsync(userId);
        return Ok(permissions);
    }

    [HttpGet("context")]
    public async Task<IActionResult> GetContext()
    {
        if (!TryGetUserId(out var userId))
        {
            return Unauthorized();
        }

        var context = await _workshopReadService.GetUserContextAsync(userId);
        return context is null ? NotFound() : Ok(context);
    }

    private bool TryGetUserId(out Guid userId)
    {
        userId = Guid.Empty;
        var userIdValue = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            ?? User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue("sub");
        return Guid.TryParse(userIdValue, out userId);
    }
}
