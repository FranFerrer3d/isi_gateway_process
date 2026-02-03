using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserRoleRepository : InMemoryRepositoryBase<UserRoleDto>, IUserRoleRepository
{
    public Task<UserRoleDto> CreateAsync(UserRoleDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
