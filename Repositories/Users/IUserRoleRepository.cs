using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.Repositories;

public interface IUserRoleRepository
{
    Task<UserRoleDto?> GetAsync(Guid id);
    Task<IReadOnlyList<UserRoleDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<UserRoleDto> CreateAsync(UserRoleDto dto);
    Task<bool> UpdateAsync(Guid id, UserRoleDto dto);
    Task<bool> DeleteAsync(Guid id);
}
