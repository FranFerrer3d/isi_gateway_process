using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryModuleRepository : InMemoryRepositoryBase<ModuleDto>, IModuleRepository
{
    public Task<ModuleDto> AddAsync(ModuleDto module) => AddAsync(module.Id, module);

    public Task<bool> UpdateAsync(ModuleDto module) => UpdateAsync(module.Id, module);
}
