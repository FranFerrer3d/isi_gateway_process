namespace IsiGatewayProcess.DTOs.Inventory.Requests;

public record class CreateContainerRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid AreaId { get; init; }
}
