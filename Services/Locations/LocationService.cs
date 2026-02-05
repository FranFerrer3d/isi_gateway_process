using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Locations;
using IsiGatewayProcess.DTOs.Locations.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public LocationService(ILocationRepository locationRepository, IOrganizationRepository organizationRepository)
    {
        _locationRepository = locationRepository;
        _organizationRepository = organizationRepository;
    }

    public Task<LocationDto?> GetAsync(Guid id) => _locationRepository.GetAsync(id);

    public async Task<PagedResult<LocationDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _locationRepository.ListAsync(skip, normalizedPageSize);
        var total = await _locationRepository.CountAsync();
        var totalPages = PagingHelper.CalculateTotalPages(total, normalizedPageSize);
        return new PagedResult<LocationDto>(items, normalizedPage, normalizedPageSize, total, totalPages);
    }

    public async Task<LocationDto> CreateAsync(CreateLocationRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var organization = await _organizationRepository.GetAsync(request.OrganizationId);
        if (organization is null)
        {
            throw new InvalidOperationException("Organization does not exist.");
        }

        var now = DateTimeOffset.UtcNow;
        var location = new LocationDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = request.OrganizationId,
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            Country = request.Country,
            RegistrationDate = now,
            DeregistrationDate = null,
        };

        return await _locationRepository.AddAsync(location);
    }

    public async Task<LocationDto?> UpdateAsync(Guid id, UpdateLocationRequest request)
    {
        var existing = await _locationRepository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }

        RequestGuard.EnsureRequiredString(request.Name, nameof(request.Name));
        var organization = await _organizationRepository.GetAsync(request.OrganizationId);
        if (organization is null)
        {
            throw new InvalidOperationException("Organization does not exist.");
        }

        var updated = existing with
        {
            OrganizationId = request.OrganizationId,
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            Country = request.Country,
            RegistrationDate = request.RegistrationDate,
            DeregistrationDate = request.DeregistrationDate,
        };

        var saved = await _locationRepository.UpdateAsync(updated);
        return saved ? updated : null;
    }

    public Task<bool> DeleteAsync(Guid id) => _locationRepository.DeleteAsync(id);
}
