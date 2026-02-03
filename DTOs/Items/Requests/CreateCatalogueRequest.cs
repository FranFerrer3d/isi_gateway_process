namespace IsiGatewayProcess.DTOs.Items.Requests;

public record class CreateCatalogueRequest
{
    public Guid ItemId { get; init; }
    public decimal Price { get; init; }
    public string Reference { get; init; } = default!;
}
