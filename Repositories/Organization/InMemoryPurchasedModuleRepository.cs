using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryPurchasedModuleRepository : InMemoryRepositoryBase<PurchasedModuleDto>, IPurchasedModuleRepository
{
    public Task<PurchasedModuleDto> CreateAsync(PurchasedModuleDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
