using IsiGatewayProcess.DTOs.Roles;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryRoleRepository : InMemoryRepositoryBase<RoleDto>, IRoleRepository
{
    public Task<RoleDto> AddAsync(RoleDto role) => AddAsync(role.Id, role);

    public Task<bool> UpdateAsync(RoleDto role) => UpdateAsync(role.Id, role);

    public Task<bool> AnyForOrganizationAsync(Guid organizationId)
    {
        var exists = Store.Values.Any(item => item.OrganizationId == organizationId);
        return Task.FromResult(exists);
    }
}
