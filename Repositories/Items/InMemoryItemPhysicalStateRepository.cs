using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryItemPhysicalStateRepository : InMemoryRepositoryBase<ItemPhysicalStateDto>, IItemPhysicalStateRepository
{
    public Task<ItemPhysicalStateDto> CreateAsync(ItemPhysicalStateDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
