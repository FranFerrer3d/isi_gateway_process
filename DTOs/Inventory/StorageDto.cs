namespace IsiGatewayProcess.DTOs.Inventory;

public record class StorageDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid LocationId { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
