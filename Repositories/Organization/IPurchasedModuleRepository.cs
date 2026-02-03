using IsiGatewayProcess.DTOs.Organization;

namespace IsiGatewayProcess.Repositories;

public interface IPurchasedModuleRepository
{
    Task<PurchasedModuleDto?> GetAsync(Guid id);
    Task<IReadOnlyList<PurchasedModuleDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<PurchasedModuleDto> CreateAsync(PurchasedModuleDto dto);
    Task<bool> UpdateAsync(Guid id, PurchasedModuleDto dto);
    Task<bool> DeleteAsync(Guid id);
}
