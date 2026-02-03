namespace IsiGatewayProcess.Repositories;

public interface IUserCredentialRepository
{
    Task<string?> GetPasswordHashAsync(Guid userId);
    Task SetPasswordHashAsync(Guid userId, string passwordHash);
}
