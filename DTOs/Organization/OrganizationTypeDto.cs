namespace IsiGatewayProcess.DTOs.Organization;

public record class OrganizationTypeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
