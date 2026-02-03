namespace IsiGatewayProcess.DTOs.Channel;

public record class PetitionDetailDto
{
    public Guid Id { get; init; }
    public Guid PetitionId { get; init; }
    public Guid ItemId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Amount { get; init; }
}
