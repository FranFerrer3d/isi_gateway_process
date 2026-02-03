namespace IsiGatewayProcess.DTOs.Users.Requests;

public record class CreateUserRequest
{
    public Guid OrganizationId { get; init; }
    public Guid LocationId { get; init; }
    public Guid UserRoleId { get; init; }
    public string UserName { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}
