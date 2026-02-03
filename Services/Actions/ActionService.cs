using IsiGatewayProcess.DTOs.Actions;
using IsiGatewayProcess.DTOs.Actions.Requests;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ActionService : IActionService
{
    private readonly IActionRepository _actionRepository;

    public ActionService(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }

    public Task<ActionDto?> GetAsync(Guid id) => _actionRepository.GetAsync(id);

    public async Task<PagedResult<ActionDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _actionRepository.ListAsync(skip, normalizedPageSize);
        var total = await _actionRepository.CountAsync();
        return new PagedResult<ActionDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ActionDto> CreateAsync(CreateActionRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var action = new ActionDto
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
        };

        return await _actionRepository.AddAsync(action);
    }

    public async Task<ActionDto?> UpdateAsync(Guid id, UpdateActionRequest request)
    {
        var existing = await _actionRepository.GetAsync(id);
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

        var saved = await _actionRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public Task<bool> DeleteAsync(Guid id) => _actionRepository.DeleteAsync(id);
}
