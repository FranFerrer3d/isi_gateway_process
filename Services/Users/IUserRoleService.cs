using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users.Requests;

namespace IsiGatewayProcess.Services;

public interface IUserRoleService
{
    Task<UserRoleDto?> GetAsync(Guid id);
    Task<PagedResult<UserRoleDto>> ListAsync(int page, int pageSize);
    Task<UserRoleDto> CreateAsync(CreateUserRoleRequest request);
    Task<UserRoleDto?> UpdateAsync(Guid id, UpdateUserRoleRequest request);
    Task<bool> DeleteAsync(Guid id);
}
