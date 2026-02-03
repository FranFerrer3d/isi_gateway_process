using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.DTOs.Organizations.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public OrganizationService(
        IOrganizationRepository organizationRepository,
        ILocationRepository locationRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository)
    {
        _organizationRepository = organizationRepository;
        _locationRepository = locationRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public Task<OrganizationDto?> GetAsync(Guid id) => _organizationRepository.GetAsync(id);

    public async Task<PagedResult<OrganizationDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _organizationRepository.ListAsync(skip, normalizedPageSize);
        var total = await _organizationRepository.CountAsync();
        return new PagedResult<OrganizationDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var now = DateTimeOffset.UtcNow;
        var organization = new OrganizationDto
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            OrganizationTypeId = request.OrganizationTypeId,
            CompanyId = request.CompanyId,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            Country = request.Country,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            RegistrationDate = now,
            DeregistrationDate = null,
        };
        return await _organizationRepository.AddAsync(organization);
    }

    public async Task<OrganizationDto?> UpdateAsync(Guid id, UpdateOrganizationRequest request)
    {
        var existing = await _organizationRepository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }

        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var updated = existing with
        {
            Name = request.Name,
            Description = request.Description,
            OrganizationTypeId = request.OrganizationTypeId,
            CompanyId = request.CompanyId,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            Country = request.Country,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            RegistrationDate = request.RegistrationDate,
            DeregistrationDate = request.DeregistrationDate,
        };

        var saved = await _organizationRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public async Task<OrganizationDeleteResult> DeleteAsync(Guid id)
    {
        var existing = await _organizationRepository.GetAsync(id);
        if (existing is null)
        {
            return OrganizationDeleteResult.NotFound;
        }

        if (await _locationRepository.AnyForOrganizationAsync(id) ||
            await _userRepository.AnyForOrganizationAsync(id) ||
            await _roleRepository.AnyForOrganizationAsync(id))
        {
            return OrganizationDeleteResult.Conflict;
        }

        var deleted = await _organizationRepository.DeleteAsync(id);
        return deleted ? OrganizationDeleteResult.Deleted : OrganizationDeleteResult.NotFound;
    }
}
