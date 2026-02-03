namespace IsiGatewayProcess.DTOs.Users;

public record class UserRoleDto
{
    public Guid Id { get; init; }
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
    public Guid OrganizationId { get; init; }
}
