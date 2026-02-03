using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;

namespace IsiGatewayProcess.Services;

public interface IPurchasedModuleService
{
    Task<PurchasedModuleDto?> GetAsync(Guid id);
    Task<PagedResult<PurchasedModuleDto>> ListAsync(int page, int pageSize);
    Task<PurchasedModuleDto> CreateAsync(CreatePurchasedModuleRequest request);
    Task<PurchasedModuleDto?> UpdateAsync(Guid id, UpdatePurchasedModuleRequest request);
    Task<bool> DeleteAsync(Guid id);
}
