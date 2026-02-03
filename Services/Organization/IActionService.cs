using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;

namespace IsiGatewayProcess.Services;

public interface IActionService
{
    Task<ActionDto?> GetAsync(Guid id);
    Task<PagedResult<ActionDto>> ListAsync(int page, int pageSize);
    Task<ActionDto> CreateAsync(CreateActionRequest request);
    Task<ActionDto?> UpdateAsync(Guid id, UpdateActionRequest request);
    Task<bool> DeleteAsync(Guid id);
}
