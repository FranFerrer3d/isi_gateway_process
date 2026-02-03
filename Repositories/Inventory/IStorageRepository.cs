using IsiGatewayProcess.DTOs.Inventory;

namespace IsiGatewayProcess.Repositories;

public interface IStorageRepository
{
    Task<StorageDto?> GetAsync(Guid id);
    Task<IReadOnlyList<StorageDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<StorageDto> CreateAsync(StorageDto dto);
    Task<bool> UpdateAsync(Guid id, StorageDto dto);
    Task<bool> DeleteAsync(Guid id);
}
