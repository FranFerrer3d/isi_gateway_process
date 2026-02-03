using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Roles;
using IsiGatewayProcess.DTOs.Roles.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public RoleService(IRoleRepository roleRepository, IOrganizationRepository organizationRepository)
    {
        _roleRepository = roleRepository;
        _organizationRepository = organizationRepository;
    }

    public Task<RoleDto?> GetAsync(Guid id) => _roleRepository.GetAsync(id);

    public async Task<PagedResult<RoleDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _roleRepository.ListAsync(skip, normalizedPageSize);
        var total = await _roleRepository.CountAsync();
        return new PagedResult<RoleDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<RoleDto> CreateAsync(CreateRoleRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        var organization = await _organizationRepository.GetAsync(request.OrganizationId);
        if (organization is null)
        {
            throw new InvalidOperationException("Organization does not exist.");
        }

        var role = new RoleDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = request.OrganizationId,
            Code = request.Code,
            Description = request.Description,
        };

        return await _roleRepository.AddAsync(role);
    }

    public async Task<RoleDto?> UpdateAsync(Guid id, UpdateRoleRequest request)
    {
        var existing = await _roleRepository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }

        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        var organization = await _organizationRepository.GetAsync(request.OrganizationId);
        if (organization is null)
        {
            throw new InvalidOperationException("Organization does not exist.");
        }

        var updated = existing with
        {
            OrganizationId = request.OrganizationId,
            Code = request.Code,
            Description = request.Description,
        };

        var saved = await _roleRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public Task<bool> DeleteAsync(Guid id) => _roleRepository.DeleteAsync(id);
}
