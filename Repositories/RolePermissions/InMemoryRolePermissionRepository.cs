using IsiGatewayProcess.DTOs.RolePermissions;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryRolePermissionRepository : InMemoryRepositoryBase<RolePermissionDto>, IRolePermissionRepository
{
    public Task<RolePermissionDto> AddAsync(RolePermissionDto rolePermission) => AddAsync(rolePermission.Id, rolePermission);

    public Task<bool> UpdateAsync(RolePermissionDto rolePermission) => UpdateAsync(rolePermission.Id, rolePermission);

    public Task<IReadOnlyList<RolePermissionDto>> ListByRoleIdAsync(Guid roleId)
    {
        IReadOnlyList<RolePermissionDto> items = Store.Values.Where(item => item.RoleId == roleId).ToList();
        return Task.FromResult(items);
    }
}
