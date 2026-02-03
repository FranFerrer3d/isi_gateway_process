using IsiGatewayProcess.DTOs.Actions;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryActionRepository : InMemoryRepositoryBase<ActionDto>, IActionRepository
{
    public Task<ActionDto> AddAsync(ActionDto action) => AddAsync(action.Id, action);

    public Task<bool> UpdateAsync(ActionDto action) => UpdateAsync(action.Id, action);
}
