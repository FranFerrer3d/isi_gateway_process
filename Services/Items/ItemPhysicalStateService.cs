using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ItemPhysicalStateService : IItemPhysicalStateService
{
    private readonly IItemPhysicalStateRepository _repository;

    public ItemPhysicalStateService(IItemPhysicalStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<ItemPhysicalStateDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<ItemPhysicalStateDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ItemPhysicalStateDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ItemPhysicalStateDto> CreateAsync(CreateItemPhysicalStateRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var dto = new ItemPhysicalStateDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<ItemPhysicalStateDto?> UpdateAsync(Guid id, UpdateItemPhysicalStateRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new ItemPhysicalStateDto
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
