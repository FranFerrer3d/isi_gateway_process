using IsiGatewayProcess.DTOs.Locations;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryLocationRepository : InMemoryRepositoryBase<LocationDto>, ILocationRepository
{
    public Task<LocationDto> AddAsync(LocationDto location) => AddAsync(location.Id, location);

    public Task<bool> UpdateAsync(LocationDto location) => UpdateAsync(location.Id, location);

    public Task<bool> AnyForOrganizationAsync(Guid organizationId)
    {
        var exists = Store.Values.Any(item => item.OrganizationId == organizationId);
        return Task.FromResult(exists);
    }
}
