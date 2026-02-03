using IsiGatewayProcess.DTOs.Roles;

namespace IsiGatewayProcess.Repositories;

public interface IRoleRepository
{
    Task<RoleDto?> GetAsync(Guid id);
    Task<IReadOnlyList<RoleDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<RoleDto> AddAsync(RoleDto role);
    Task<bool> UpdateAsync(RoleDto role);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> AnyForOrganizationAsync(Guid organizationId);
}
