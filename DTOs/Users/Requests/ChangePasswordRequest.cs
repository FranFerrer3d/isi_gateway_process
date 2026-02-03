namespace IsiGatewayProcess.DTOs.Users.Requests;

public record class ChangePasswordRequest
{
    public string CurrentPassword { get; init; } = default!;
    public string NewPassword { get; init; } = default!;
}
