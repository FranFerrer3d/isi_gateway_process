using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Organization.Requests;

namespace IsiGatewayProcess.Services;

public interface IOrganizationTypeService
{
    Task<OrganizationTypeDto?> GetAsync(Guid id);
    Task<PagedResult<OrganizationTypeDto>> ListAsync(int page, int pageSize);
    Task<OrganizationTypeDto> CreateAsync(CreateOrganizationTypeRequest request);
    Task<OrganizationTypeDto?> UpdateAsync(Guid id, UpdateOrganizationTypeRequest request);
    Task<bool> DeleteAsync(Guid id);
}
