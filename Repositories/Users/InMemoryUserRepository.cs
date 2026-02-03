using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserRepository : InMemoryRepositoryBase<UserDto>, IUserRepository
{
    public Task<UserDto> AddAsync(UserDto user) => AddAsync(user.Id, user);

    public Task<bool> UpdateAsync(UserDto user) => UpdateAsync(user.Id, user);

    public Task<UserDto?> FindByUserNameOrEmailAsync(string userNameOrEmail)
    {
        var user = Store.Values.FirstOrDefault(item =>
            string.Equals(item.UserName, userNameOrEmail, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(item.Email, userNameOrEmail, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(user);
    }

    public Task<bool> AnyForOrganizationAsync(Guid organizationId)
    {
        var exists = Store.Values.Any(item => item.OrganizationId == organizationId);
        return Task.FromResult(exists);
    }

    public Task<bool> AnyForLocationAsync(Guid locationId)
    {
        var exists = Store.Values.Any(item => item.LocationId == locationId);
        return Task.FromResult(exists);
    }
}
