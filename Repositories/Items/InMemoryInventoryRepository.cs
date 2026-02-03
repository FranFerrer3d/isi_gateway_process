using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryInventoryRepository : InMemoryRepositoryBase<InventoryDto>, IInventoryRepository
{
    public Task<InventoryDto> CreateAsync(InventoryDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
