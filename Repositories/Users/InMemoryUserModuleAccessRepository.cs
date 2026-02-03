using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryUserModuleAccessRepository : InMemoryRepositoryBase<UserModuleAccessDto>, IUserModuleAccessRepository
{
    public Task<UserModuleAccessDto> CreateAsync(UserModuleAccessDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
