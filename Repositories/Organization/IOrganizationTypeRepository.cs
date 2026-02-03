using IsiGatewayProcess.DTOs.Organization;

namespace IsiGatewayProcess.Repositories;

public interface IOrganizationTypeRepository
{
    Task<OrganizationTypeDto?> GetAsync(Guid id);
    Task<IReadOnlyList<OrganizationTypeDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<OrganizationTypeDto> CreateAsync(OrganizationTypeDto dto);
    Task<bool> UpdateAsync(Guid id, OrganizationTypeDto dto);
    Task<bool> DeleteAsync(Guid id);
}
