using System.Collections.Concurrent;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserCredentialRepository : IUserCredentialRepository
{
    private static readonly ConcurrentDictionary<Guid, string> Store = new();

    public Task<string?> GetPasswordHashAsync(Guid userId)
    {
        Store.TryGetValue(userId, out var hash);
        return Task.FromResult(hash);
    }

    public Task SetPasswordHashAsync(Guid userId, string passwordHash)
    {
        Store[userId] = passwordHash;
        return Task.CompletedTask;
    }
}
