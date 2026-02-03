using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Inventory.Requests;

namespace IsiGatewayProcess.Services;

public interface IContainerService
{
    Task<ContainerDto?> GetAsync(Guid id);
    Task<PagedResult<ContainerDto>> ListAsync(int page, int pageSize);
    Task<ContainerDto> CreateAsync(CreateContainerRequest request);
    Task<ContainerDto?> UpdateAsync(Guid id, UpdateContainerRequest request);
    Task<bool> DeleteAsync(Guid id);
}
