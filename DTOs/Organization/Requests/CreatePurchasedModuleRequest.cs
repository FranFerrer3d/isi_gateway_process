namespace IsiGatewayProcess.DTOs.Organization.Requests;

public record class CreatePurchasedModuleRequest
{
    public Guid OrganizationId { get; init; }
    public Guid ModuleId { get; init; }
}
