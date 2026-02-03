using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryOrganizationTypeRepository : InMemoryRepositoryBase<OrganizationTypeDto>, IOrganizationTypeRepository
{
    public Task<OrganizationTypeDto> CreateAsync(OrganizationTypeDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
