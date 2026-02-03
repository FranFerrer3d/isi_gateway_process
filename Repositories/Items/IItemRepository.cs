using IsiGatewayProcess.DTOs.Items;

namespace IsiGatewayProcess.Repositories;

public interface IItemRepository
{
    Task<ItemDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ItemDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ItemDto> CreateAsync(ItemDto dto);
    Task<bool> UpdateAsync(Guid id, ItemDto dto);
    Task<bool> DeleteAsync(Guid id);
}
