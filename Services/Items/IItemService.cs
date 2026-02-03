using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;

namespace IsiGatewayProcess.Services;

public interface IItemService
{
    Task<ItemDto?> GetAsync(Guid id);
    Task<PagedResult<ItemDto>> ListAsync(int page, int pageSize);
    Task<ItemDto> CreateAsync(CreateItemRequest request);
    Task<ItemDto?> UpdateAsync(Guid id, UpdateItemRequest request);
    Task<bool> DeleteAsync(Guid id);
}
