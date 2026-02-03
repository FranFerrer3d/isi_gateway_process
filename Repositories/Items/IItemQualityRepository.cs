using IsiGatewayProcess.DTOs.Items;

namespace IsiGatewayProcess.Repositories;

public interface IItemQualityRepository
{
    Task<ItemQualityDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ItemQualityDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ItemQualityDto> CreateAsync(ItemQualityDto dto);
    Task<bool> UpdateAsync(Guid id, ItemQualityDto dto);
    Task<bool> DeleteAsync(Guid id);
}
