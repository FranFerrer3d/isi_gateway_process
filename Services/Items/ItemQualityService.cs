using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ItemQualityService : IItemQualityService
{
    private readonly IItemQualityRepository _repository;

    public ItemQualityService(IItemQualityRepository repository)
    {
        _repository = repository;
    }

    public async Task<ItemQualityDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<ItemQualityDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ItemQualityDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ItemQualityDto> CreateAsync(CreateItemQualityRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var dto = new ItemQualityDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<ItemQualityDto?> UpdateAsync(Guid id, UpdateItemQualityRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new ItemQualityDto
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
