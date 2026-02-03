namespace IsiGatewayProcess.DTOs.Users.Requests;

public record class UpdateUserRequest
{
    public string UserName { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public Guid UserRoleId { get; init; }
    public Guid LocationId { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
