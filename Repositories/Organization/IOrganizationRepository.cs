using IsiGatewayProcess.DTOs.Organization;

namespace IsiGatewayProcess.Repositories;

public interface IOrganizationRepository
{
    Task<OrganizationDto?> GetAsync(Guid id);
    Task<IReadOnlyList<OrganizationDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<OrganizationDto> CreateAsync(OrganizationDto dto);
    Task<bool> UpdateAsync(Guid id, OrganizationDto dto);
    Task<bool> DeleteAsync(Guid id);
}
