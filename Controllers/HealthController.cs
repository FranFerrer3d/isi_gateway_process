using IsiGatewayProcess.Filters;
using IsiGatewayProcess.DTOs;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsiGatewayProcess.Controllers;

[ApiController]
[Route("api/v1/health")]
[JWTAuth]
public class HealthController : ControllerBase
{
    private readonly IHealthService _healthService;

    public HealthController(IHealthService healthService)
    {
        _healthService = healthService;
    }

    [HttpGet]
    public ActionResult<HealthResponseDto> Get()
    {
        return Ok(_healthService.GetHealth());
    }
}
