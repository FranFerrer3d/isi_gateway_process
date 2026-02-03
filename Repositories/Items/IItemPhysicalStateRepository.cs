using IsiGatewayProcess.DTOs.Items;

namespace IsiGatewayProcess.Repositories;

public interface IItemPhysicalStateRepository
{
    Task<ItemPhysicalStateDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ItemPhysicalStateDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ItemPhysicalStateDto> CreateAsync(ItemPhysicalStateDto dto);
    Task<bool> UpdateAsync(Guid id, ItemPhysicalStateDto dto);
    Task<bool> DeleteAsync(Guid id);
}
