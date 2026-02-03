using IsiGatewayProcess.DTOs.Organization;

namespace IsiGatewayProcess.Repositories;

public interface IModuleRepository
{
    Task<ModuleDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ModuleDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ModuleDto> CreateAsync(ModuleDto dto);
    Task<bool> UpdateAsync(Guid id, ModuleDto dto);
    Task<bool> DeleteAsync(Guid id);
}
