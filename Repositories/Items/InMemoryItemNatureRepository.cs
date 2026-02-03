using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryItemNatureRepository : InMemoryRepositoryBase<ItemNatureDto>, IItemNatureRepository
{
    public Task<ItemNatureDto> CreateAsync(ItemNatureDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
