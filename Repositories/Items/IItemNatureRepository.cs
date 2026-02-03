using IsiGatewayProcess.DTOs.Items;

namespace IsiGatewayProcess.Repositories;

public interface IItemNatureRepository
{
    Task<ItemNatureDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ItemNatureDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ItemNatureDto> CreateAsync(ItemNatureDto dto);
    Task<bool> UpdateAsync(Guid id, ItemNatureDto dto);
    Task<bool> DeleteAsync(Guid id);
}
