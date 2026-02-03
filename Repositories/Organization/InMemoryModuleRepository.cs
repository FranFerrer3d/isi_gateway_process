using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryModuleRepository : InMemoryRepositoryBase<ModuleDto>, IModuleRepository
{
    public Task<ModuleDto> CreateAsync(ModuleDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
