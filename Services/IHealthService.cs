using IsiGatewayProcess.DTOs;

namespace IsiGatewayProcess.Services;

public interface IHealthService
{
    HealthResponseDto GetHealth();
}
