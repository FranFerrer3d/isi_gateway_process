namespace IsiGatewayProcess.DTOs.Items.Requests;

public record class UpdateCatalogueRequest
{
    public Guid ItemId { get; init; }
    public decimal Price { get; init; }
    public string Reference { get; init; } = default!;
    public DateTimeOffset? DeregistrationDate { get; init; }
}
