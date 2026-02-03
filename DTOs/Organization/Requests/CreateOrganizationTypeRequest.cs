namespace IsiGatewayProcess.DTOs.Organization.Requests;

public record class CreateOrganizationTypeRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
