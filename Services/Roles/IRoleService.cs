using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Roles;
using IsiGatewayProcess.DTOs.Roles.Requests;

namespace IsiGatewayProcess.Services;

public interface IRoleService
{
    Task<RoleDto?> GetAsync(Guid id);
    Task<PagedResult<RoleDto>> ListAsync(int page, int pageSize);
    Task<RoleDto> CreateAsync(CreateRoleRequest request);
    Task<RoleDto?> UpdateAsync(Guid id, UpdateRoleRequest request);
    Task<bool> DeleteAsync(Guid id);
}
