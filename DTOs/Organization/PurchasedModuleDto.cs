namespace IsiGatewayProcess.DTOs.Organization;

public record class PurchasedModuleDto
{
    public Guid Id { get; init; }
    public Guid OrganizationId { get; init; }
    public Guid ModuleId { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
