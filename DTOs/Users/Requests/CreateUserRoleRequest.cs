namespace IsiGatewayProcess.DTOs.Users.Requests;

public record class CreateUserRoleRequest
{
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
    public Guid OrganizationId { get; init; }
}
