using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users.Requests;

namespace IsiGatewayProcess.Services;

public interface IUserModuleAccessService
{
    Task<UserModuleAccessDto?> GetAsync(Guid id);
    Task<PagedResult<UserModuleAccessDto>> ListAsync(int page, int pageSize);
    Task<UserModuleAccessDto> CreateAsync(CreateUserModuleAccessRequest request);
    Task<UserModuleAccessDto?> UpdateAsync(Guid id, UpdateUserModuleAccessRequest request);
    Task<bool> DeleteAsync(Guid id);
}
