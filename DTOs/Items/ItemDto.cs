namespace IsiGatewayProcess.DTOs.Items;

public record class ItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid ItemPhysicalStateId { get; init; }
    public Guid ItemNatureId { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
