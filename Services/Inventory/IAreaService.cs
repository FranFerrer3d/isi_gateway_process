using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Inventory.Requests;

namespace IsiGatewayProcess.Services;

public interface IAreaService
{
    Task<AreaDto?> GetAsync(Guid id);
    Task<PagedResult<AreaDto>> ListAsync(int page, int pageSize);
    Task<AreaDto> CreateAsync(CreateAreaRequest request);
    Task<AreaDto?> UpdateAsync(Guid id, UpdateAreaRequest request);
    Task<bool> DeleteAsync(Guid id);
}
