using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Inventory.Requests;

namespace IsiGatewayProcess.Services;

public interface IStorageService
{
    Task<StorageDto?> GetAsync(Guid id);
    Task<PagedResult<StorageDto>> ListAsync(int page, int pageSize);
    Task<StorageDto> CreateAsync(CreateStorageRequest request);
    Task<StorageDto?> UpdateAsync(Guid id, UpdateStorageRequest request);
    Task<bool> DeleteAsync(Guid id);
}
