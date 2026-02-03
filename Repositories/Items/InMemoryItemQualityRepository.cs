using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryItemQualityRepository : InMemoryRepositoryBase<ItemQualityDto>, IItemQualityRepository
{
    public Task<ItemQualityDto> CreateAsync(ItemQualityDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
