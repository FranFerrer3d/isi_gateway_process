namespace IsiGatewayProcess.DTOs.Organization;

public record class ActionDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
