using IsiGatewayProcess.DTOs.Actions;
using IsiGatewayProcess.DTOs.Actions.Requests;
using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.Services;

public interface IActionService
{
    Task<ActionDto?> GetAsync(Guid id);
    Task<PagedResult<ActionDto>> ListAsync(int page, int pageSize);
    Task<ActionDto> CreateAsync(CreateActionRequest request);
    Task<ActionDto?> UpdateAsync(Guid id, UpdateActionRequest request);
    Task<bool> DeleteAsync(Guid id);
}
