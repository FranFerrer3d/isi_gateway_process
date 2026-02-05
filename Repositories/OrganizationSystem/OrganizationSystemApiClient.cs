using System.Net.Http.Json;
using System.Linq;
using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.DTOs.Organizations;

namespace IsiGatewayProcess.Repositories.OrganizationSystem;

public class OrganizationSystemApiClient
{
    private readonly HttpClient _httpClient;

    public OrganizationSystemApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ModuleDto?> GetModuleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var module = await _httpClient.GetFromJsonAsync<OrganizationSystemModuleDto>($"/api/v1/ModuleById/{id}", cancellationToken);
        return module is null ? null : MapModule(module);
    }

    public async Task<ModuleDto?> GetModuleByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var module = await _httpClient.GetFromJsonAsync<OrganizationSystemModuleDto>(
            $"/api/v1/ModuleByName/{Uri.EscapeDataString(name)}",
            cancellationToken);
        return module is null ? null : MapModule(module);
    }

    public async Task<IReadOnlyList<ModuleDto>> GetModulesAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        try {
            var endpoint = $"/api/v1/ModuleList?Page={page}&PageSize={pageSize}";
            var items = await _httpClient.GetFromJsonAsync<List<OrganizationSystemModuleDto>>(endpoint, cancellationToken);
            return items?.Select(MapModule).ToList() ?? [];

        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error fetching modules: {ex.Message}");
            throw;
        }
       
    }

    public async Task<Guid> CreateModuleAsync(ModuleDto module, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/Module", new { module = new { name = module.Name, description = module.Description } }, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
    }

    public async Task<Guid> UpdateModuleAsync(ModuleDto module, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync("/api/v1/Module", new { module = new { id = module.Id, name = module.Name, description = module.Description } }, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken) ;
    }

    public async Task<Guid> DeleteModuleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"/api/v1/Module/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
    }

    public async Task<OrganizationDto?> GetOrganizationByIdAsync(Guid id, bool? deregistrated, CancellationToken cancellationToken = default)
    {
        var query = deregistrated.HasValue ? $"?deregistrated={deregistrated.Value.ToString().ToLowerInvariant()}" : string.Empty;
        var organization = await _httpClient.GetFromJsonAsync<OrganizationSystemOrganizationDto>(
            $"/api/v1/OrganizationById/{id}{query}",
            cancellationToken);
        return organization is null ? null : MapOrganization(organization);
    }

    public async Task<OrganizationDto?> GetOrganizationByNameAsync(string name, bool? deregistrated, CancellationToken cancellationToken = default)
    {
        var query = deregistrated.HasValue ? $"?deregistrated={deregistrated.Value.ToString().ToLowerInvariant()}" : string.Empty;
        var organization = await _httpClient.GetFromJsonAsync<OrganizationSystemOrganizationDto>(
            $"/api/v1/OrganizationByName/{Uri.EscapeDataString(name)}{query}",
            cancellationToken);
        return organization is null ? null : MapOrganization(organization);
    }

    public async Task<IReadOnlyList<OrganizationDto>> GetOrganizationsAsync(int page, int pageSize, bool? deregistrated, CancellationToken cancellationToken = default)
    {
        var query = $"?Page={page}&PageSize={pageSize}";
        if (deregistrated.HasValue)
        {
            query += $"&deregistrated={deregistrated.Value.ToString().ToLowerInvariant()}";
        }

        var items = await _httpClient.GetFromJsonAsync<List<OrganizationSystemOrganizationDto>>(
            $"/api/v1/OrganizationList{query}",
            cancellationToken);
        return items?.Select(MapOrganization).ToList() ?? [];
    }

    public async Task<Guid> CreateOrganizationAsync(OrganizationDto organization, CancellationToken cancellationToken = default)
    {
        var payload = new
        {
            organization = new
            {
                name = organization.Name,
                description = organization.Description,
                organizationTypeId = organization.OrganizationTypeId,
                parentId = organization.CompanyId,
                maxPurchasedUsers = (int?)null,
                address = organization.Address,
                city = organization.City,
                region = organization.Region,
                country = organization.Country,
                email = organization.Email,
                phoneNumber = organization.PhoneNumber,
                registrationDate = organization.RegistrationDate,
                deregistrationDate = organization.DeregistrationDate,
            }
        };
        var response = await _httpClient.PostAsJsonAsync("/api/v1/Organization", payload, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
    }

    public async Task<Guid> UpdateOrganizationAsync(OrganizationDto organization, bool? deregistrated, CancellationToken cancellationToken = default)
    {
        var payload = new
        {
            organization = new
            {
                id = organization.Id,
                name = organization.Name,
                description = organization.Description,
                organizationTypeId = organization.OrganizationTypeId,
                parentId = organization.CompanyId,
                maxPurchasedUsers = (int?)null,
                address = organization.Address,
                city = organization.City,
                region = organization.Region,
                country = organization.Country,
                email = organization.Email,
                phoneNumber = organization.PhoneNumber,
                registrationDate = organization.RegistrationDate,
                deregistrationDate = organization.DeregistrationDate,
            }
        };

        var query = deregistrated.HasValue ? $"?deregistrated={deregistrated.Value.ToString().ToLowerInvariant()}" : string.Empty;
        var response = await _httpClient.PutAsJsonAsync($"/api/v1/Organization{query}", payload, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
    }

    public async Task<Guid> DeleteOrganizationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"/api/v1/Organization/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
    }

    private static ModuleDto MapModule(OrganizationSystemModuleDto module)
    {
        return new ModuleDto
        {
            Id = module.Id,
            Code = module.Name ?? string.Empty,
            Name = module.Name ?? string.Empty,
            Description = module.Description,
        };
    }

    private static OrganizationDto MapOrganization(OrganizationSystemOrganizationDto organization)
    {
        return new OrganizationDto
        {
            Id = organization.Id,
            Name = organization.Name ?? string.Empty,
            Description = organization.Description,
            OrganizationTypeId = organization.OrganizationType?.Id,
            CompanyId = organization.Parent?.Id,
            Address = organization.Address,
            City = organization.City,
            Region = organization.Region,
            Country = organization.Country,
            Email = organization.Email,
            PhoneNumber = organization.PhoneNumber,
            RegistrationDate = organization.RegistrationDate ?? DateTimeOffset.MinValue,
            DeregistrationDate = organization.DeregistrationDate,
        };
    }

    private sealed record OrganizationSystemModuleDto(Guid Id, string? Name, string? Description);

    private sealed record OrganizationSystemOrganizationDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public OrganizationSystemOrganizationTypeDto? OrganizationType { get; init; }
        public OrganizationSystemOrganizationDto? Parent { get; init; }
        public int? MaxPurchasedUsers { get; init; }
        public string? Address { get; init; }
        public string? City { get; init; }
        public string? Region { get; init; }
        public string? Country { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public DateTimeOffset? RegistrationDate { get; init; }
        public DateTimeOffset? DeregistrationDate { get; init; }
    }

    private sealed record OrganizationSystemOrganizationTypeDto(Guid Id);
}
