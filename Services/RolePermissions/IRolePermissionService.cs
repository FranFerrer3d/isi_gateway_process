using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.RolePermissions;
using IsiGatewayProcess.DTOs.RolePermissions.Requests;

namespace IsiGatewayProcess.Services;

public interface IRolePermissionService
{
    Task<RolePermissionDto?> GetAsync(Guid id);
    //Task<PagedResult<RolePermissionDto>> ListAsync(int page, int pageSize);
    Task<RolePermissionDto> CreateAsync(CreateRolePermissionRequest request);
    Task<RolePermissionDto?> UpdateAsync(Guid id, UpdateRolePermissionRequest request);
    Task<bool> DeleteAsync(Guid id);
}
