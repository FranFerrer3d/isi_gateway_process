using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Users.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserCredentialRepository _credentialRepository;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        IUserCredentialRepository credentialRepository,
        IOrganizationRepository organizationRepository,
        ILocationRepository locationRepository,
        IRoleRepository roleRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _credentialRepository = credentialRepository;
        _organizationRepository = organizationRepository;
        _locationRepository = locationRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<UserDto?> GetAsync(Guid id) => _userRepository.GetAsync(id);

    public async Task<PagedResult<UserDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _userRepository.ListAsync(skip, normalizedPageSize);
        var total = await _userRepository.CountAsync();
        return new PagedResult<UserDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<UserDto> CreateAsync(CreateUserRequest request)
    {
        RequestGuard.EnsureRequiredString(request.UserName, nameof(request.UserName));
        RequestGuard.EnsureRequiredString(request.Email, nameof(request.Email));
        RequestGuard.EnsureRequiredString(request.Password, nameof(request.Password));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        RequestGuard.EnsureRequiredString(request.LastName, nameof(request.LastName));

        await EnsureRelationshipsAsync(request.OrganizationId, request.LocationId, request.UserRoleId);

        var now = DateTimeOffset.UtcNow;
        var user = new UserDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = request.OrganizationId,
            LocationId = request.LocationId,
            UserRoleId = request.UserRoleId,
            UserName = request.UserName,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            RegistrationDate = now,
            DeregistrationDate = null,
        };

        var created = await _userRepository.AddAsync(user);
        await _credentialRepository.SetPasswordHashAsync(created.Id, _passwordHasher.Hash(request.Password));
        return created;
    }

    public async Task<UserDto?> UpdateAsync(Guid id, UpdateUserRequest request)
    {
        var existing = await _userRepository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }

        RequestGuard.EnsureRequiredString(request.UserName, nameof(request.UserName));
        RequestGuard.EnsureRequiredString(request.Email, nameof(request.Email));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        RequestGuard.EnsureRequiredString(request.LastName, nameof(request.LastName));

        await EnsureRelationshipsAsync(request.OrganizationId, request.LocationId, request.UserRoleId);

        var updated = existing with
        {
            OrganizationId = request.OrganizationId,
            LocationId = request.LocationId,
            UserRoleId = request.UserRoleId,
            UserName = request.UserName,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            RegistrationDate = request.RegistrationDate,
            DeregistrationDate = request.DeregistrationDate,
        };

        var saved = await _userRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public Task<bool> DeleteAsync(Guid id) => _userRepository.DeleteAsync(id);

    private async Task EnsureRelationshipsAsync(Guid organizationId, Guid locationId, Guid roleId)
    {
        var organization = await _organizationRepository.GetAsync(organizationId);
        if (organization is null)
        {
            throw new InvalidOperationException("Organization does not exist.");
        }

        var location = await _locationRepository.GetAsync(locationId);
        if (location is null)
        {
            throw new InvalidOperationException("Location does not exist.");
        }

        if (location.OrganizationId != organizationId)
        {
            throw new InvalidOperationException("Location does not belong to organization.");
        }

        var role = await _roleRepository.GetAsync(roleId);
        if (role is null)
        {
            throw new InvalidOperationException("Role does not exist.");
        }

        if (role.OrganizationId != organizationId)
        {
            throw new InvalidOperationException("Role does not belong to organization.");
        }
    }
}
