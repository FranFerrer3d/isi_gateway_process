namespace IsiGatewayProcess.DTOs.RolePermissions.Requests;

public record class CreateRolePermissionRequest
{
    public Guid RoleId { get; init; }
    public Guid ModuleId { get; init; }
    public Guid ActionId { get; init; }
}
