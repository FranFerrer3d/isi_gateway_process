using IsiGatewayProcess.DTOs.RolePermissions;

namespace IsiGatewayProcess.Repositories;

public interface IRolePermissionRepository
{
    Task<RolePermissionDto?> GetAsync(Guid id);
    Task<IReadOnlyList<RolePermissionDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<RolePermissionDto> AddAsync(RolePermissionDto rolePermission);
    Task<bool> UpdateAsync(RolePermissionDto rolePermission);
    Task<bool> DeleteAsync(Guid id);
    Task<IReadOnlyList<RolePermissionDto>> ListByRoleIdAsync(Guid roleId);
}
