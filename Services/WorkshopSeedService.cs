using System.Threading;
using IsiGatewayProcess.Repositories;

namespace IsiGatewayProcess.Services;

public sealed class WorkshopSeedService : IWorkshopSeedService
{
    private static int _seeded;

    private readonly WorkshopMockDatabase _database;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IModuleRepository _moduleRepository;
    private readonly IActionRepository _actionRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IUserCredentialRepository _userCredentialRepository;
    private readonly IPasswordHasher _passwordHasher;

    public WorkshopSeedService(WorkshopMockDatabase database, IOrganizationRepository organizationRepository, ILocationRepository locationRepository, IModuleRepository moduleRepository, IActionRepository actionRepository, IRoleRepository roleRepository, IUserRepository userRepository, IRolePermissionRepository rolePermissionRepository, IUserCredentialRepository userCredentialRepository, IPasswordHasher passwordHasher)
    {
        _database = database;
        _organizationRepository = organizationRepository;
        _locationRepository = locationRepository;
        _moduleRepository = moduleRepository;
        _actionRepository = actionRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _rolePermissionRepository = rolePermissionRepository;
        _userCredentialRepository = userCredentialRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (Interlocked.Exchange(ref _seeded, 1) == 1)
        {
            return;
        }

        var snapshot = _database.Snapshot;

        foreach (var organization in snapshot.Organizations)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _organizationRepository.AddAsync(organization);
        }

        foreach (var location in snapshot.Locations)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _locationRepository.AddAsync(location);
        }

        foreach (var module in snapshot.Modules)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _moduleRepository.AddAsync(module);
        }

        foreach (var action in snapshot.Actions)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _actionRepository.AddAsync(action);
        }

        foreach (var role in snapshot.Roles)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _roleRepository.AddAsync(role);
        }

        foreach (var user in snapshot.Users)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _userRepository.AddAsync(user);
            await _userCredentialRepository.SetPasswordHashAsync(user.Id, _passwordHasher.Hash(snapshot.PlainTextPasswords[user.Id]));
        }

        foreach (var permission in snapshot.RolePermissions)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _rolePermissionRepository.AddAsync(permission);
        }
    }
}
