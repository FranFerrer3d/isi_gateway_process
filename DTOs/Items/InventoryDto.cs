namespace IsiGatewayProcess.DTOs.Items;

public record class InventoryDto
{
    public Guid Id { get; init; }
    public Guid CatalogueId { get; init; }
    public Guid ContainerId { get; init; }
    public Guid ItemQualityId { get; init; }
    public decimal Quantity { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
