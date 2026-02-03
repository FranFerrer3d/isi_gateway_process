using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.RolePermissions;
using IsiGatewayProcess.DTOs.RolePermissions.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IModuleRepository _moduleRepository;
    private readonly IActionRepository _actionRepository;

    public RolePermissionService(
        IRolePermissionRepository rolePermissionRepository,
        IRoleRepository roleRepository,
        IModuleRepository moduleRepository,
        IActionRepository actionRepository)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _roleRepository = roleRepository;
        _moduleRepository = moduleRepository;
        _actionRepository = actionRepository;
    }

    public Task<RolePermissionDto?> GetAsync(Guid id) => _rolePermissionRepository.GetAsync(id);

    public async Task<PagedResult<RolePermissionDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _rolePermissionRepository.ListAsync(skip, normalizedPageSize);
        var total = await _rolePermissionRepository.CountAsync();
        return new PagedResult<RolePermissionDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<RolePermissionDto> CreateAsync(CreateRolePermissionRequest request)
    {
        await EnsureReferencesExistAsync(request.RoleId, request.ModuleId, request.ActionId);
        var rolePermission = new RolePermissionDto
        {
            Id = Guid.NewGuid(),
            RoleId = request.RoleId,
            ModuleId = request.ModuleId,
            ActionId = request.ActionId,
        };

        return await _rolePermissionRepository.AddAsync(rolePermission);
    }

    public async Task<RolePermissionDto?> UpdateAsync(Guid id, UpdateRolePermissionRequest request)
    {
        var existing = await _rolePermissionRepository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }

        await EnsureReferencesExistAsync(request.RoleId, request.ModuleId, request.ActionId);
        var updated = existing with
        {
            RoleId = request.RoleId,
            ModuleId = request.ModuleId,
            ActionId = request.ActionId,
        };

        var saved = await _rolePermissionRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public Task<bool> DeleteAsync(Guid id) => _rolePermissionRepository.DeleteAsync(id);

    private async Task EnsureReferencesExistAsync(Guid roleId, Guid moduleId, Guid actionId)
    {
        if (await _roleRepository.GetAsync(roleId) is null)
        {
            throw new InvalidOperationException("Role does not exist.");
        }

        if (await _moduleRepository.GetAsync(moduleId) is null)
        {
            throw new InvalidOperationException("Module does not exist.");
        }

        if (await _actionRepository.GetAsync(actionId) is null)
        {
            throw new InvalidOperationException("Action does not exist.");
        }
    }
}
