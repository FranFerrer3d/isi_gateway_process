namespace IsiGatewayProcess.DTOs.Channel.Requests;

public record class UpdatePetitionStatusRequest
{
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
}
