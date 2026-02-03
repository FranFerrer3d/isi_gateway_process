namespace IsiGatewayProcess.DTOs.Items;

public record class CatalogueDto
{
    public Guid Id { get; init; }
    public Guid ItemId { get; init; }
    public decimal Price { get; init; }
    public string Reference { get; init; } = default!;
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
