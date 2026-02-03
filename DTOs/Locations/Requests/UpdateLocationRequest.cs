namespace IsiGatewayProcess.DTOs.Locations.Requests;

public record class UpdateLocationRequest
{
    public Guid OrganizationId { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? Country { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
