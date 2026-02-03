namespace IsiGatewayProcess.DTOs.Auth;

public record class RevokeRequest
{
    public string RefreshToken { get; init; } = default!;
}
