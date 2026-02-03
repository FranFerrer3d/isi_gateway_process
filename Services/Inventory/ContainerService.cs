using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Inventory.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class ContainerService : IContainerService
{
    private readonly IContainerRepository _repository;

    public ContainerService(IContainerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContainerDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<ContainerDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ContainerDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<ContainerDto> CreateAsync(CreateContainerRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new ContainerDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            AreaId = request.AreaId,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<ContainerDto?> UpdateAsync(Guid id, UpdateContainerRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var dto = new ContainerDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            AreaId = request.AreaId,
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
