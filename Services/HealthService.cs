using IsiGatewayProcess.DTOs;

namespace IsiGatewayProcess.Services;

public class HealthService : IHealthService
{
    public HealthResponseDto GetHealth()
    {
        return new HealthResponseDto();
    }
}
