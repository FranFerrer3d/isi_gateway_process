using IsiGatewayProcess.DTOs.Workshop;

namespace IsiGatewayProcess.Services;

public interface IWorkshopReadService
{
    Task<WorkshopLookupsDto> GetLookupsAsync();
    Task<WorkshopBootstrapDto> GetBootstrapAsync();
    Task<IReadOnlyList<WorkshopCatalogueEntryDto>> GetCatalogueAsync(Guid? itemId = null, Guid? catalogueId = null);
    Task<IReadOnlyList<WorkshopInventoryEntryDto>> GetInventoryAsync(Guid? storageId = null, Guid? itemId = null, Guid? catalogueId = null);
    Task<IReadOnlyList<WorkshopPetitionViewDto>> GetPetitionsAsync(string? statusCode = null, Guid? petitionaryOrganizationId = null, Guid? receiverOrganizationId = null);
    Task<IReadOnlyList<WorkshopAuditViewDto>> GetAuditAsync();
    Task<WorkshopUserContextDto?> GetUserContextAsync(Guid userId);
}
