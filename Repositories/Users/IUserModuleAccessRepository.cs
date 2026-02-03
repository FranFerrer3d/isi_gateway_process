using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.Repositories;

public interface IUserModuleAccessRepository
{
    Task<UserModuleAccessDto?> GetAsync(Guid id);
    Task<IReadOnlyList<UserModuleAccessDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<UserModuleAccessDto> CreateAsync(UserModuleAccessDto dto);
    Task<bool> UpdateAsync(Guid id, UserModuleAccessDto dto);
    Task<bool> DeleteAsync(Guid id);
}
