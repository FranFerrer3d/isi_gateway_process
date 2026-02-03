namespace IsiGatewayProcess.DTOs.Roles.Requests;

public record class UpdateRoleRequest
{
    public Guid OrganizationId { get; init; }
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
}
