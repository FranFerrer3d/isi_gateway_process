namespace IsiGatewayProcess.DTOs.Channel.Requests;

public record class CreatePetitionStatusRequest
{
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
}
