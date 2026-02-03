using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.Repositories;

public interface IUserRepository
{
    Task<UserDto?> GetAsync(Guid id);
    Task<IReadOnlyList<UserDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<UserDto> AddAsync(UserDto user);
    Task<bool> UpdateAsync(UserDto user);
    Task<bool> DeleteAsync(Guid id);
    Task<UserDto?> FindByUserNameOrEmailAsync(string userNameOrEmail);
    Task<bool> AnyForOrganizationAsync(Guid organizationId);
    Task<bool> AnyForLocationAsync(Guid locationId);
}
