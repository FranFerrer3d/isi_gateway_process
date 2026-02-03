using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;

namespace IsiGatewayProcess.Services;

public interface IItemPhysicalStateService
{
    Task<ItemPhysicalStateDto?> GetAsync(Guid id);
    Task<PagedResult<ItemPhysicalStateDto>> ListAsync(int page, int pageSize);
    Task<ItemPhysicalStateDto> CreateAsync(CreateItemPhysicalStateRequest request);
    Task<ItemPhysicalStateDto?> UpdateAsync(Guid id, UpdateItemPhysicalStateRequest request);
    Task<bool> DeleteAsync(Guid id);
}
