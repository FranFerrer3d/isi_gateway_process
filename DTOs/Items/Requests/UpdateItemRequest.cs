namespace IsiGatewayProcess.DTOs.Items.Requests;

public record class UpdateItemRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid ItemPhysicalStateId { get; init; }
    public Guid ItemNatureId { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
