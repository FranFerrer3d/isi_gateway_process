namespace IsiGatewayProcess.Services;

public interface IWorkshopSeedService
{
    Task SeedAsync(CancellationToken cancellationToken = default);
}
