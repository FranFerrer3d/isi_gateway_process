using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<ItemDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<ItemDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ItemDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ItemDto> CreateAsync(CreateItemRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new ItemDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            ItemPhysicalStateId = request.ItemPhysicalStateId,
            ItemNatureId = request.ItemNatureId,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<ItemDto?> UpdateAsync(Guid id, UpdateItemRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new ItemDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            ItemPhysicalStateId = request.ItemPhysicalStateId,
            ItemNatureId = request.ItemNatureId,
            RegistrationDate = existing.RegistrationDate,
            DeregistrationDate = request.DeregistrationDate,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
