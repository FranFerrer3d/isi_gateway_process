using System.Collections.Concurrent;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserCredentialRepository : IUserCredentialRepository
{
    private readonly ConcurrentDictionary<Guid, string> _store = new();

    public Task<string?> GetPasswordHashAsync(Guid userId)
    {
        _store.TryGetValue(userId, out var hash);
        return Task.FromResult(hash);
    }

    public Task SetPasswordHashAsync(Guid userId, string passwordHash)
    {
        _store[userId] = passwordHash;
        return Task.CompletedTask;
    }
}
