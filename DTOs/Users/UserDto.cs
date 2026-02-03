namespace IsiGatewayProcess.DTOs.Users;

public record class UserDto
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? LastName { get; init; }
    public string Email { get; init; } = default!;
    public Guid UserRoleId { get; init; }
    public Guid LocationId { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
