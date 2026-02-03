using IsiGatewayProcess.DTOs.Locations;

namespace IsiGatewayProcess.Repositories;

public interface ILocationRepository
{
    Task<LocationDto?> GetAsync(Guid id);
    Task<IReadOnlyList<LocationDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<LocationDto> AddAsync(LocationDto location);
    Task<bool> UpdateAsync(LocationDto location);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> AnyForOrganizationAsync(Guid organizationId);
}
