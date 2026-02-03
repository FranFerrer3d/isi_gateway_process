using IsiGatewayProcess.DTOs.Organizations;

namespace IsiGatewayProcess.Repositories;

public interface IOrganizationRepository
{
    Task<OrganizationDto?> GetAsync(Guid id);
    Task<IReadOnlyList<OrganizationDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<OrganizationDto> AddAsync(OrganizationDto organization);
    Task<bool> UpdateAsync(OrganizationDto organization);
    Task<bool> DeleteAsync(Guid id);
}
