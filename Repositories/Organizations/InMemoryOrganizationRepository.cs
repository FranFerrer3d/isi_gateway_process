using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryOrganizationRepository : InMemoryRepositoryBase<OrganizationDto>, IOrganizationRepository
{
    public Task<OrganizationDto> AddAsync(OrganizationDto organization) => AddAsync(organization.Id, organization);

    public Task<bool> UpdateAsync(OrganizationDto organization) => UpdateAsync(organization.Id, organization);
}
