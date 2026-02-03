using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ActionService : IActionService
{
    private readonly IActionRepository _repository;

    public ActionService(IActionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ActionDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<ActionDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ActionDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ActionDto> CreateAsync(CreateActionRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var dto = new ActionDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<ActionDto?> UpdateAsync(Guid id, UpdateActionRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new ActionDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
