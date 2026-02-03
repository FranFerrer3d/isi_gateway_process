using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.DTOs.Roles;

public record class RoleDto : EntityDto
{
    public Guid OrganizationId { get; init; }
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
}
