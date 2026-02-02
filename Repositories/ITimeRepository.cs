namespace IsiGatewayProcess.Repositories;

public interface ITimeRepository
{
    DateTimeOffset GetCurrentUtc();
}
