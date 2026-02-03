using IsiGatewayProcess.DTOs.Permissions;

namespace IsiGatewayProcess.Services;

public interface IPermissionService
{
    Task<IReadOnlyList<PermissionDto>> GetPermissionsForUserAsync(Guid userId);
}
