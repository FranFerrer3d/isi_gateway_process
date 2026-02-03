namespace IsiGatewayProcess.DTOs.Audit;

public record class AuditDto
{
    public Guid Id { get; init; }
    public Guid ModuleId { get; init; }
    public Guid ActionId { get; init; }
    public Guid UserId { get; init; }
    public DateTimeOffset OperationTime { get; init; }
    public Guid AffectedElementId { get; init; }
    public string? AffectedElementInformation { get; init; }
}
