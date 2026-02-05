using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.Repositories.OrganizationSystem;

namespace IsiGatewayProcess.Repositories;

public class OrganizationSystemModuleRepository : IModuleRepository
{
    private readonly OrganizationSystemApiClient _apiClient;

    public OrganizationSystemModuleRepository(OrganizationSystemApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ModuleDto?> GetAsync(Guid id) => _apiClient.GetModuleByIdAsync(id);

    public async Task<IReadOnlyList<ModuleDto>> ListAsync(int skip, int take)
    {
        var page = Math.Max(1, (skip / Math.Max(1, take)) + 1);
        return await _apiClient.GetModulesAsync(page, take);
    }

    public Task<int> CountAsync() => Task.FromResult(0);

    public async Task<ModuleDto> AddAsync(ModuleDto module)
    {
        var id = await _apiClient.CreateModuleAsync(module);
        return module with { Id = id };
    }

    public async Task<bool> UpdateAsync(ModuleDto module)
    {
        await _apiClient.UpdateModuleAsync(module);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _apiClient.DeleteModuleAsync(id);
        return true;
    }
}
