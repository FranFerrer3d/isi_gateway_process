namespace IsiGatewayProcess.DTOs.Auth;

public record class LoginRequest
{
    public string UserNameOrEmail { get; init; } = default!;
    public string Password { get; init; } = default!;
}
