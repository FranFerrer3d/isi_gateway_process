using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IUserCredentialRepository _credentialRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(
        IUserRepository repository,
        IUserCredentialRepository credentialRepository,
        IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _credentialRepository = credentialRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<UserDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<UserDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<UserDto> CreateAsync(CreateUserRequest request)
    {
        RequestGuard.EnsureRequiredString(request.UserName, nameof(request.UserName));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        RequestGuard.EnsureRequiredString(request.LastName, nameof(request.LastName));
        RequestGuard.EnsureRequiredString(request.Email, nameof(request.Email));
        RequestGuard.EnsureRequiredString(request.Password, nameof(request.Password));
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new UserDto
        {
            Id = id,
            UserName = request.UserName,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            UserRoleId = request.UserRoleId,
            LocationId = request.LocationId,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        var created = await _repository.CreateAsync(dto);
        var passwordHash = _passwordHasher.Hash(request.Password);
        await _credentialRepository.SetPasswordHashAsync(created.Id, passwordHash);
        return created;
    }

    public async Task<UserDto?> UpdateAsync(Guid id, UpdateUserRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.UserName, nameof(request.UserName));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        RequestGuard.EnsureRequiredString(request.LastName, nameof(request.LastName));
        RequestGuard.EnsureRequiredString(request.Email, nameof(request.Email));
        var dto = new UserDto
        {
            Id = id,
            UserName = request.UserName,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            UserRoleId = request.UserRoleId,
            LocationId = request.LocationId,
            RegistrationDate = existing.RegistrationDate,
            DeregistrationDate = request.DeregistrationDate,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool?> ChangePasswordAsync(Guid id, ChangePasswordRequest request)
    {
        RequestGuard.EnsureRequiredString(request.CurrentPassword, nameof(request.CurrentPassword));
        RequestGuard.EnsureRequiredString(request.NewPassword, nameof(request.NewPassword));
        var user = await _repository.GetAsync(id);
        if (user is null)
        {
            return null;
        }

        var passwordHash = await _credentialRepository.GetPasswordHashAsync(id);
        if (string.IsNullOrWhiteSpace(passwordHash) || !_passwordHasher.Verify(request.CurrentPassword, passwordHash))
        {
            return false;
        }

        var newHash = _passwordHasher.Hash(request.NewPassword);
        await _credentialRepository.SetPasswordHashAsync(id, newHash);
        return true;
    }
}
