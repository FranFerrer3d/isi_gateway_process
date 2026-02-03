using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;

namespace IsiGatewayProcess.Services;

public interface IItemQualityService
{
    Task<ItemQualityDto?> GetAsync(Guid id);
    Task<PagedResult<ItemQualityDto>> ListAsync(int page, int pageSize);
    Task<ItemQualityDto> CreateAsync(CreateItemQualityRequest request);
    Task<ItemQualityDto?> UpdateAsync(Guid id, UpdateItemQualityRequest request);
    Task<bool> DeleteAsync(Guid id);
}
