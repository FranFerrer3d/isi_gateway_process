namespace IsiGatewayProcess.Repositories;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshTokenRecord record);
    Task<RefreshTokenRecord?> FindValidAsync(string tokenHash, DateTimeOffset now);
    Task<RefreshTokenRecord?> FindByTokenHashAsync(string tokenHash);
    Task RevokeAsync(Guid recordId, DateTimeOffset revokedAt, string? replacedByTokenHash);
    Task RevokeAllForUserAsync(Guid userId, DateTimeOffset revokedAt);
}
