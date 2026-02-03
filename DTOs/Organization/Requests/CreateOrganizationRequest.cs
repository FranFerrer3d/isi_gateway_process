namespace IsiGatewayProcess.DTOs.Organization.Requests;

public record class CreateOrganizationRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid OrganizationTypeId { get; init; }
    public Guid CompanyId { get; init; }
    public int MaxPurchasedUsers { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? Country { get; init; }
    public string Email { get; init; } = default!;
    public string? PhoneNumber { get; init; }
}
