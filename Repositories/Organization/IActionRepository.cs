using IsiGatewayProcess.DTOs.Organization;

namespace IsiGatewayProcess.Repositories;

public interface IActionRepository
{
    Task<ActionDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ActionDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ActionDto> CreateAsync(ActionDto dto);
    Task<bool> UpdateAsync(Guid id, ActionDto dto);
    Task<bool> DeleteAsync(Guid id);
}
