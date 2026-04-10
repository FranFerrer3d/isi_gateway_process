using System.Collections.Concurrent;

namespace IsiGatewayProcess.Repositories;

public class InMemoryRefreshTokenRepository : IRefreshTokenRepository
{
    private static readonly ConcurrentDictionary<Guid, RefreshTokenRecord> Store = new();

    public Task AddAsync(RefreshTokenRecord record)
    {
        Store[record.Id] = record;
        return Task.CompletedTask;
    }

    public Task<RefreshTokenRecord?> FindValidAsync(string tokenHash, DateTimeOffset now)
    {
        var record = Store.Values.FirstOrDefault(item =>
            string.Equals(item.TokenHash, tokenHash, StringComparison.Ordinal) &&
            item.RevokedAt is null &&
            item.ExpiresAt > now);
        return Task.FromResult(record);
    }

    public Task<RefreshTokenRecord?> FindByTokenHashAsync(string tokenHash)
    {
        var record = Store.Values.FirstOrDefault(item =>
            string.Equals(item.TokenHash, tokenHash, StringComparison.Ordinal));
        return Task.FromResult(record);
    }

    public Task RevokeAsync(Guid recordId, DateTimeOffset revokedAt, string? replacedByTokenHash)
    {
        if (!Store.TryGetValue(recordId, out var existing))
        {
            return Task.CompletedTask;
        }

        var updated = existing with { RevokedAt = revokedAt, ReplacedByTokenHash = replacedByTokenHash };
        Store.TryUpdate(recordId, updated, existing);
        return Task.CompletedTask;
    }

    public Task RevokeAllForUserAsync(Guid userId, DateTimeOffset revokedAt)
    {
        foreach (var entry in Store.Values.Where(item => item.UserId == userId && item.RevokedAt is null))
        {
            var updated = entry with { RevokedAt = revokedAt };
            Store.TryUpdate(entry.Id, updated, entry);
        }

        return Task.CompletedTask;
    }
}
