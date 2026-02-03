using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.DTOs.Modules.Requests;

namespace IsiGatewayProcess.Services;

public interface IModuleService
{
    Task<ModuleDto?> GetAsync(Guid id);
    Task<PagedResult<ModuleDto>> ListAsync(int page, int pageSize);
    Task<ModuleDto> CreateAsync(CreateModuleRequest request);
    Task<ModuleDto?> UpdateAsync(Guid id, UpdateModuleRequest request);
    Task<bool> DeleteAsync(Guid id);
}
