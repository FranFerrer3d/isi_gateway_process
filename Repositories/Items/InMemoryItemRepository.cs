using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryItemRepository : InMemoryRepositoryBase<ItemDto>, IItemRepository
{
    public Task<ItemDto> CreateAsync(ItemDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
