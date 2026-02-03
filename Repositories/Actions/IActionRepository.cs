using IsiGatewayProcess.DTOs.Actions;

namespace IsiGatewayProcess.Repositories;

public interface IActionRepository
{
    Task<ActionDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ActionDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ActionDto> AddAsync(ActionDto action);
    Task<bool> UpdateAsync(ActionDto action);
    Task<bool> DeleteAsync(Guid id);
}
