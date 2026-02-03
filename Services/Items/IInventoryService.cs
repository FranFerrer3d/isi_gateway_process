using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;

namespace IsiGatewayProcess.Services;

public interface IInventoryService
{
    Task<InventoryDto?> GetAsync(Guid id);
    Task<PagedResult<InventoryDto>> ListAsync(int page, int pageSize);
    Task<InventoryDto> CreateAsync(CreateInventoryRequest request);
    Task<InventoryDto?> UpdateAsync(Guid id, UpdateInventoryRequest request);
    Task<bool> DeleteAsync(Guid id);
}
