namespace IsiGatewayProcess.DTOs.Inventory.Requests;

public record class CreateAreaRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid StorageId { get; init; }
}
