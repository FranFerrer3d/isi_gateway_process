namespace IsiGatewayProcess.DTOs.Items.Requests;

public record class CreateInventoryRequest
{
    public Guid CatalogueId { get; init; }
    public Guid ContainerId { get; init; }
    public Guid ItemQualityId { get; init; }
    public decimal Quantity { get; init; }
}
