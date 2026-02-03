namespace IsiGatewayProcess.DTOs.Channel;

public record class PetitionDto
{
    public Guid Id { get; init; }
    public Guid PetitionaryUserId { get; init; }
    public Guid PetitionaryOrganizationId { get; init; }
    public Guid ReceiverOrganizationId { get; init; }
    public Guid StatusId { get; init; }
    public DateTimeOffset EstimatedTimeArrival { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
