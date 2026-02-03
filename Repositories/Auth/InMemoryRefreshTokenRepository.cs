using System.Collections.Concurrent;

namespace IsiGatewayProcess.Repositories;

public class InMemoryRefreshTokenRepository : IRefreshTokenRepository
{
    private readonly ConcurrentDictionary<Guid, RefreshTokenRecord> _store = new();

    public Task AddAsync(RefreshTokenRecord record)
    {
        _store[record.Id] = record;
        return Task.CompletedTask;
    }

    public Task<RefreshTokenRecord?> FindValidAsync(string tokenHash, DateTimeOffset now)
    {
        var record = _store.Values.FirstOrDefault(item =>
            string.Equals(item.TokenHash, tokenHash, StringComparison.Ordinal) &&
            item.RevokedAt is null &&
            item.ExpiresAt > now);
        return Task.FromResult(record);
    }

    public Task<RefreshTokenRecord?> FindByTokenHashAsync(string tokenHash)
    {
        var record = _store.Values.FirstOrDefault(item =>
            string.Equals(item.TokenHash, tokenHash, StringComparison.Ordinal));
        return Task.FromResult(record);
    }

    public Task RevokeAsync(Guid recordId, DateTimeOffset revokedAt, string? replacedByTokenHash)
    {
        if (!_store.TryGetValue(recordId, out var existing))
        {
            return Task.CompletedTask;
        }

        var updated = existing with { RevokedAt = revokedAt, ReplacedByTokenHash = replacedByTokenHash };
        _store.TryUpdate(recordId, updated, existing);
        return Task.CompletedTask;
    }

    public Task RevokeAllForUserAsync(Guid userId, DateTimeOffset revokedAt)
    {
        foreach (var entry in _store.Values.Where(item => item.UserId == userId && item.RevokedAt is null))
        {
            var updated = entry with { RevokedAt = revokedAt };
            _store.TryUpdate(entry.Id, updated, entry);
        }

        return Task.CompletedTask;
    }
}
