namespace IsiGatewayProcess.DTOs;

public record class HealthResponseDto
{
    public string Status { get; init; } = "OK";
    public DateTimeOffset CheckedAt { get; init; } = DateTimeOffset.UtcNow;
}
