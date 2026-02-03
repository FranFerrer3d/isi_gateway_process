using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Inventory.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class StorageService : IStorageService
{
    private readonly IStorageRepository _repository;

    public StorageService(IStorageRepository repository)
    {
        _repository = repository;
    }

    public async Task<StorageDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<StorageDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<StorageDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<StorageDto> CreateAsync(CreateStorageRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new StorageDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            LocationId = request.LocationId,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<StorageDto?> UpdateAsync(Guid id, UpdateStorageRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new StorageDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            LocationId = request.LocationId,
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
