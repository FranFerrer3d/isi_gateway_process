namespace IsiGatewayProcess.DTOs.Inventory.Requests;

public record class UpdateStorageRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid LocationId { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
