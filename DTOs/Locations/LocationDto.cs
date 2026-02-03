using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.DTOs.Locations;

public record class LocationDto : RegistrableEntityDto
{
    public Guid OrganizationId { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? Country { get; init; }
}
