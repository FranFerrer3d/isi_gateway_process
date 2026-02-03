namespace IsiGatewayProcess.DTOs.Organization.Requests;

public record class UpdateOrganizationTypeRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
