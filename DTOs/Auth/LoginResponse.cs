namespace IsiGatewayProcess.DTOs.Auth;

public record class LoginResponse
{
    public string AccessToken { get; init; } = default!;
    public DateTimeOffset AccessTokenExpiresAt { get; init; }
    public string RefreshToken { get; init; } = default!;
    public DateTimeOffset RefreshTokenExpiresAt { get; init; }
}
