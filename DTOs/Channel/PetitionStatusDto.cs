namespace IsiGatewayProcess.DTOs.Channel;

public record class PetitionStatusDto
{
    public Guid Id { get; init; }
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
}
