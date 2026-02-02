using IsiGatewayProcess.DTOs;
using IsiGatewayProcess.Repositories;

namespace IsiGatewayProcess.Services;

public class HealthService : IHealthService
{
    private readonly ITimeRepository _timeRepository;

    public HealthService(ITimeRepository timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public HealthResponseDto GetHealth()
    {
        return new HealthResponseDto("ok", _timeRepository.GetCurrentUtc());
    }
}
