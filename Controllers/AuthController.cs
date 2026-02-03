using IsiGatewayProcess.DTOs.Auth;
using IsiGatewayProcess.Filters;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        return response is null ? Unauthorized() : Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshRequest request)
    {
        var response = await _authService.RefreshAsync(request);
        return response is null ? Unauthorized() : Ok(response);
    }

    [JWTAuth]
    [HttpPost("revoke")]
    public async Task<IActionResult> Revoke(RevokeRequest request)
    {
        var revoked = await _authService.RevokeAsync(request);
        return revoked ? NoContent() : BadRequest();
    }
}
