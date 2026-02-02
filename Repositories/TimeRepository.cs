namespace IsiGatewayProcess.Repositories;

public class TimeRepository : ITimeRepository
{
    public DateTimeOffset GetCurrentUtc()
    {
        return DateTimeOffset.UtcNow;
    }
}
