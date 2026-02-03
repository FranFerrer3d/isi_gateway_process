using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryActionRepository : InMemoryRepositoryBase<ActionDto>, IActionRepository
{
    public Task<ActionDto> CreateAsync(ActionDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
