using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryContainerRepository : InMemoryRepositoryBase<ContainerDto>, IContainerRepository
{
    public Task<ContainerDto> CreateAsync(ContainerDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
