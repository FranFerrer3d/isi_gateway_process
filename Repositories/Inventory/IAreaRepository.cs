using IsiGatewayProcess.DTOs.Inventory;

namespace IsiGatewayProcess.Repositories;

public interface IAreaRepository
{
    Task<AreaDto?> GetAsync(Guid id);
    Task<IReadOnlyList<AreaDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<AreaDto> CreateAsync(AreaDto dto);
    Task<bool> UpdateAsync(Guid id, AreaDto dto);
    Task<bool> DeleteAsync(Guid id);
}
