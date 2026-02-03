namespace IsiGatewayProcess.Repositories;

public record class RefreshTokenRecord
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string TokenHash { get; init; } = default!;
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ExpiresAt { get; init; }
    public DateTimeOffset? RevokedAt { get; init; }
    public string? ReplacedByTokenHash { get; init; }
}
