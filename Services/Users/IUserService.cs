using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users.Requests;

namespace IsiGatewayProcess.Services;

public interface IUserService
{
    Task<UserDto?> GetAsync(Guid id);
    Task<PagedResult<UserDto>> ListAsync(int page, int pageSize);
    Task<UserDto> CreateAsync(CreateUserRequest request);
    Task<UserDto?> UpdateAsync(Guid id, UpdateUserRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<bool?> ChangePasswordAsync(Guid id, ChangePasswordRequest request);
}
