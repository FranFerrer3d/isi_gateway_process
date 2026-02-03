using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _repository;

    public OrganizationService(IOrganizationRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganizationDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<OrganizationDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<OrganizationDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        RequestGuard.EnsureRequiredString(request.Email, nameof(request.Email));
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new OrganizationDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            OrganizationTypeId = request.OrganizationTypeId,
            CompanyId = request.CompanyId,
            MaxPurchasedUsers = request.MaxPurchasedUsers,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            Country = request.Country,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<OrganizationDto?> UpdateAsync(Guid id, UpdateOrganizationRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        RequestGuard.EnsureRequiredString(request.Email, nameof(request.Email));
        var dto = new OrganizationDto
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            OrganizationTypeId = request.OrganizationTypeId,
            CompanyId = request.CompanyId,
            MaxPurchasedUsers = request.MaxPurchasedUsers,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            Country = request.Country,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
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
