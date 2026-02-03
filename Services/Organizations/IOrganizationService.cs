using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.DTOs.Organizations.Requests;

namespace IsiGatewayProcess.Services;

public interface IOrganizationService
{
    Task<OrganizationDto?> GetAsync(Guid id);
    Task<PagedResult<OrganizationDto>> ListAsync(int page, int pageSize);
    Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request);
    Task<OrganizationDto?> UpdateAsync(Guid id, UpdateOrganizationRequest request);
    Task<OrganizationDeleteResult> DeleteAsync(Guid id);
}

public enum OrganizationDeleteResult
{
    Deleted,
    NotFound,
    Conflict,
}
