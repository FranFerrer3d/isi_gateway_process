using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.DTOs.RolePermissions;

public record class RolePermissionDto : EntityDto
{
    public Guid RoleId { get; init; }
    public Guid ModuleId { get; init; }
    public Guid ActionId { get; init; }
}
