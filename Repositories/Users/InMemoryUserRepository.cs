using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserRepository : InMemoryRepositoryBase<UserDto>, IUserRepository
{
    public Task<UserDto> CreateAsync(UserDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
