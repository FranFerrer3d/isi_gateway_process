namespace IsiGatewayProcess.DTOs.Channel.Requests;

public record class CreatePetitionRequest
{
    public Guid PetitionaryUserId { get; init; }
    public Guid PetitionaryOrganizationId { get; init; }
    public Guid ReceiverOrganizationId { get; init; }
    public Guid StatusId { get; init; }
    public DateTimeOffset EstimatedTimeArrival { get; init; }
}
