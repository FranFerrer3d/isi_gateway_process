using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;

namespace IsiGatewayProcess.Services;

public interface IItemNatureService
{
    Task<ItemNatureDto?> GetAsync(Guid id);
    Task<PagedResult<ItemNatureDto>> ListAsync(int page, int pageSize);
    Task<ItemNatureDto> CreateAsync(CreateItemNatureRequest request);
    Task<ItemNatureDto?> UpdateAsync(Guid id, UpdateItemNatureRequest request);
    Task<bool> DeleteAsync(Guid id);
}
