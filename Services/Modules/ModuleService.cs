using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.DTOs.Modules.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleService(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Task<ModuleDto?> GetAsync(Guid id) => _moduleRepository.GetAsync(id);

    public async Task<PagedResult<ModuleDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _moduleRepository.ListAsync(skip, normalizedPageSize);
        var total = await _moduleRepository.CountAsync();
        return new PagedResult<ModuleDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ModuleDto> CreateAsync(CreateModuleRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var module = new ModuleDto
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
        };

        return await _moduleRepository.AddAsync(module);
    }

    public async Task<ModuleDto?> UpdateAsync(Guid id, UpdateModuleRequest request)
    {
        var existing = await _moduleRepository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }

        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var updated = existing with
        {
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
        };

        var saved = await _moduleRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public Task<bool> DeleteAsync(Guid id) => _moduleRepository.DeleteAsync(id);
}
