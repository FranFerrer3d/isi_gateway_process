using IsiGatewayProcess.DTOs.Modules;

namespace IsiGatewayProcess.Repositories;

public interface IModuleRepository
{
    Task<ModuleDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ModuleDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ModuleDto> AddAsync(ModuleDto module);
    Task<bool> UpdateAsync(ModuleDto module);
    Task<bool> DeleteAsync(Guid id);
}
