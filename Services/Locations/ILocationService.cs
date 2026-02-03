using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Locations;
using IsiGatewayProcess.DTOs.Locations.Requests;

namespace IsiGatewayProcess.Services;

public interface ILocationService
{
    Task<LocationDto?> GetAsync(Guid id);
    Task<PagedResult<LocationDto>> ListAsync(int page, int pageSize);
    Task<LocationDto> CreateAsync(CreateLocationRequest request);
    Task<LocationDto?> UpdateAsync(Guid id, UpdateLocationRequest request);
    Task<bool> DeleteAsync(Guid id);
}
