using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.Repositories;

public interface IUserRepository
{
    Task<UserDto?> GetAsync(Guid id);
    Task<IReadOnlyList<UserDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<UserDto> CreateAsync(UserDto dto);
    Task<bool> UpdateAsync(Guid id, UserDto dto);
    Task<bool> DeleteAsync(Guid id);
}
