using IsiGatewayProcess.DTOs.Organization;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryOrganizationRepository : InMemoryRepositoryBase<OrganizationDto>, IOrganizationRepository
{
    public Task<OrganizationDto> CreateAsync(OrganizationDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
