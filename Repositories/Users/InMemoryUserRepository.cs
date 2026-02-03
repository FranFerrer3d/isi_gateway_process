using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserRepository : InMemoryRepositoryBase<UserDto>, IUserRepository
{
    public Task<UserDto> CreateAsync(UserDto dto)
    {
        return AddAsync(dto.Id, dto);
    }

    public Task<UserDto?> FindByUserNameOrEmailAsync(string userNameOrEmail)
    {
        var match = Store.Values.FirstOrDefault(user =>
            string.Equals(user.UserName, userNameOrEmail, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(user.Email, userNameOrEmail, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(match);
    }
}
