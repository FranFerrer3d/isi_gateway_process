using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.Repositories.OrganizationSystem;

namespace IsiGatewayProcess.Repositories;

public class OrganizationSystemOrganizationRepository : IOrganizationRepository
{
    private readonly OrganizationSystemApiClient _apiClient;

    public OrganizationSystemOrganizationRepository(OrganizationSystemApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<OrganizationDto?> GetAsync(Guid id) => _apiClient.GetOrganizationByIdAsync(id, null);

    public async Task<IReadOnlyList<OrganizationDto>> ListAsync(int skip, int take)
    {
        var page = Math.Max(1, (skip / Math.Max(1, take)) + 1);
        return await _apiClient.GetOrganizationsAsync(page, take, null);
    }

    public Task<int> CountAsync() => Task.FromResult(0);

    public async Task<OrganizationDto> AddAsync(OrganizationDto organization)
    {
        var id = await _apiClient.CreateOrganizationAsync(organization);
        return organization with { Id = id };
    }

    public async Task<bool> UpdateAsync(OrganizationDto organization)
    {
        await _apiClient.UpdateOrganizationAsync(organization, null);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _apiClient.DeleteOrganizationAsync(id);
        return true;
    }
}
