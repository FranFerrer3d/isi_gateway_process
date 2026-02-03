using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryAreaRepository : InMemoryRepositoryBase<AreaDto>, IAreaRepository
{
    public Task<AreaDto> CreateAsync(AreaDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
