namespace IsiGatewayProcess.DTOs.Inventory.Requests;

public record class UpdateContainerRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid AreaId { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
