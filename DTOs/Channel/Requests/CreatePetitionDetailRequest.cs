namespace IsiGatewayProcess.DTOs.Channel.Requests;

public record class CreatePetitionDetailRequest
{
    public Guid PetitionId { get; init; }
    public Guid ItemId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Amount { get; init; }
}
