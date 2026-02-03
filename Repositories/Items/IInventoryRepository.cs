using IsiGatewayProcess.DTOs.Items;

namespace IsiGatewayProcess.Repositories;

public interface IInventoryRepository
{
    Task<InventoryDto?> GetAsync(Guid id);
    Task<IReadOnlyList<InventoryDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<InventoryDto> CreateAsync(InventoryDto dto);
    Task<bool> UpdateAsync(Guid id, InventoryDto dto);
    Task<bool> DeleteAsync(Guid id);
}
