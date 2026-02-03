using IsiGatewayProcess.DTOs.Permissions;
using IsiGatewayProcess.Repositories;

namespace IsiGatewayProcess.Services;

public class PermissionService : IPermissionService
{
    private readonly IUserRepository _userRepository;
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IModuleRepository _moduleRepository;
    private readonly IActionRepository _actionRepository;

    public PermissionService(
        IUserRepository userRepository,
        IRolePermissionRepository rolePermissionRepository,
        IModuleRepository moduleRepository,
        IActionRepository actionRepository)
    {
        _userRepository = userRepository;
        _rolePermissionRepository = rolePermissionRepository;
        _moduleRepository = moduleRepository;
        _actionRepository = actionRepository;
    }

    public async Task<IReadOnlyList<PermissionDto>> GetPermissionsForUserAsync(Guid userId)
    {
        var user = await _userRepository.GetAsync(userId);
        if (user is null)
        {
            return Array.Empty<PermissionDto>();
        }

        var permissions = await _rolePermissionRepository.ListByRoleIdAsync(user.UserRoleId);
        if (permissions.Count == 0)
        {
            return Array.Empty<PermissionDto>();
        }

        var moduleLookup = new Dictionary<Guid, string>();
        var actionLookup = new Dictionary<Guid, string>();
        var results = new List<PermissionDto>();

        foreach (var permission in permissions)
        {
            if (!moduleLookup.TryGetValue(permission.ModuleId, out var moduleCode))
            {
                var module = await _moduleRepository.GetAsync(permission.ModuleId);
                moduleCode = module?.Code ?? string.Empty;
                moduleLookup[permission.ModuleId] = moduleCode;
            }

            if (!actionLookup.TryGetValue(permission.ActionId, out var actionCode))
            {
                var action = await _actionRepository.GetAsync(permission.ActionId);
                actionCode = action?.Code ?? string.Empty;
                actionLookup[permission.ActionId] = actionCode;
            }

            if (string.IsNullOrWhiteSpace(moduleCode) || string.IsNullOrWhiteSpace(actionCode))
            {
                continue;
            }

            results.Add(new PermissionDto
            {
                ModuleCode = moduleCode,
                ActionCode = actionCode,
            });
        }

        return results;
    }
}
