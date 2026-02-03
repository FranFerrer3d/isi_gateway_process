namespace IsiGatewayProcess.DTOs.Organization.Requests;

public record class UpdatePurchasedModuleRequest
{
    public Guid OrganizationId { get; init; }
    public Guid ModuleId { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
