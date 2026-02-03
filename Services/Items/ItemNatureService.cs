using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ItemNatureService : IItemNatureService
{
    private readonly IItemNatureRepository _repository;

    public ItemNatureService(IItemNatureRepository repository)
    {
        _repository = repository;
    }

    public async Task<ItemNatureDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<ItemNatureDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ItemNatureDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ItemNatureDto> CreateAsync(CreateItemNatureRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var dto = new ItemNatureDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<ItemNatureDto?> UpdateAsync(Guid id, UpdateItemNatureRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new ItemNatureDto
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
