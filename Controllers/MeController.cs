using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/me")]
public class MeController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public MeController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet("permissions")]
    public async Task<IActionResult> GetPermissions()
    {
        var userIdValue = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (!Guid.TryParse(userIdValue, out var userId))
        {
            return Unauthorized();
        }

        var permissions = await _permissionService.GetPermissionsForUserAsync(userId);
        return Ok(permissions);
    }
}
