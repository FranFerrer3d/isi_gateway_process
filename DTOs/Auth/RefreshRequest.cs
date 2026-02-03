namespace IsiGatewayProcess.DTOs.Auth;

public record class RefreshRequest
{
    public string RefreshToken { get; init; } = default!;
}
