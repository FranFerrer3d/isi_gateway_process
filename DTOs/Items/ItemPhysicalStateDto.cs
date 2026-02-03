namespace IsiGatewayProcess.DTOs.Items;

public record class ItemPhysicalStateDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
