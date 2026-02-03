using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class PurchasedModuleService : IPurchasedModuleService
{
    private readonly IPurchasedModuleRepository _repository;

    public PurchasedModuleService(IPurchasedModuleRepository repository)
    {
        _repository = repository;
    }

    public async Task<PurchasedModuleDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<PurchasedModuleDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<PurchasedModuleDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<PurchasedModuleDto> CreateAsync(CreatePurchasedModuleRequest request)
    {
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new PurchasedModuleDto
        {
            Id = id,
            OrganizationId = request.OrganizationId,
            ModuleId = request.ModuleId,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<PurchasedModuleDto?> UpdateAsync(Guid id, UpdatePurchasedModuleRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        var dto = new PurchasedModuleDto
        {
            Id = id,
            OrganizationId = request.OrganizationId,
            ModuleId = request.ModuleId,
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
