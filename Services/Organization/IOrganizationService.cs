using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;

namespace IsiGatewayProcess.Services;

public interface IOrganizationService
{
    Task<OrganizationDto?> GetAsync(Guid id);
    Task<PagedResult<OrganizationDto>> ListAsync(int page, int pageSize);
    Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request);
    Task<OrganizationDto?> UpdateAsync(Guid id, UpdateOrganizationRequest request);
    Task<bool> DeleteAsync(Guid id);
}
