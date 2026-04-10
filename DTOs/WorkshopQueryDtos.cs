using IsiGatewayProcess.DTOs.Permissions;
using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.DTOs.Workshop;

public record class WorkshopLookupsDto
{
    public required IReadOnlyList<DTOs.Organizations.OrganizationDto> Organizations { get; init; }
    public required IReadOnlyList<DTOs.Modules.ModuleDto> Modules { get; init; }
    public required IReadOnlyList<DTOs.Actions.ActionDto> Actions { get; init; }
    public required IReadOnlyList<DTOs.Roles.RoleDto> Roles { get; init; }
    public required IReadOnlyList<WorkshopOrganizationTypeDto> OrganizationTypes { get; init; }
    public required IReadOnlyList<WorkshopStorageTypeDto> StorageTypes { get; init; }
    public required IReadOnlyList<WorkshopItemPhysicalStateDto> ItemPhysicalStates { get; init; }
    public required IReadOnlyList<WorkshopItemNatureDto> ItemNatures { get; init; }
    public required IReadOnlyList<WorkshopReferenceTypeDto> ReferenceTypes { get; init; }
    public required IReadOnlyList<WorkshopItemQualityDto> ItemQualities { get; init; }
    public required IReadOnlyList<WorkshopPetitionStatusDto> PetitionStatuses { get; init; }
}

public record class WorkshopBootstrapDto
{
    public required WorkshopSeedSnapshot Seed { get; init; }
    public required IReadOnlyList<WorkshopCatalogueEntryDto> Catalogue { get; init; }
    public required IReadOnlyList<WorkshopInventoryEntryDto> Inventory { get; init; }
    public required IReadOnlyList<WorkshopPetitionViewDto> Petitions { get; init; }
}

public record class WorkshopCatalogueEntryDto
{
    public required WorkshopCatalogueDto Catalogue { get; init; }
    public required WorkshopItemDto Item { get; init; }
    public required IReadOnlyList<WorkshopReferenceViewDto> References { get; init; }
    public required IReadOnlyList<WorkshopInventorySummaryDto> Stock { get; init; }
    public decimal TotalQuantity { get; init; }
}

public record class WorkshopReferenceViewDto
{
    public required WorkshopReferenceDto Reference { get; init; }
    public required WorkshopReferenceTypeDto ReferenceType { get; init; }
}

public record class WorkshopInventorySummaryDto
{
    public required WorkshopInventoryDto Inventory { get; init; }
    public required WorkshopStorageDto Storage { get; init; }
    public required WorkshopStorageTypeDto StorageType { get; init; }
    public required WorkshopItemQualityDto Quality { get; init; }
}

public record class WorkshopInventoryEntryDto
{
    public required WorkshopInventoryDto Inventory { get; init; }
    public required WorkshopCatalogueDto Catalogue { get; init; }
    public required WorkshopItemDto Item { get; init; }
    public required WorkshopStorageDto Storage { get; init; }
    public required WorkshopStorageTypeDto StorageType { get; init; }
    public required WorkshopItemQualityDto Quality { get; init; }
    public required IReadOnlyList<WorkshopReferenceViewDto> References { get; init; }
}

public record class WorkshopPetitionViewDto
{
    public required WorkshopPetitionDto Petition { get; init; }
    public required UserDto PetitionaryUser { get; init; }
    public required DTOs.Organizations.OrganizationDto PetitionaryOrganization { get; init; }
    public required DTOs.Organizations.OrganizationDto ReceiverOrganization { get; init; }
    public required WorkshopPetitionStatusDto Status { get; init; }
    public required IReadOnlyList<WorkshopPetitionDetailViewDto> Details { get; init; }
}

public record class WorkshopPetitionDetailViewDto
{
    public required WorkshopPetitionDetailDto Detail { get; init; }
    public required WorkshopItemDto Item { get; init; }
}

public record class WorkshopAuditViewDto
{
    public required WorkshopAuditDto Audit { get; init; }
    public required DTOs.Modules.ModuleDto Module { get; init; }
    public required DTOs.Actions.ActionDto Action { get; init; }
    public required UserDto User { get; init; }
}

public record class WorkshopUserModuleViewDto
{
    public required WorkshopUserModuleDto Assignment { get; init; }
    public required WorkshopPurchasedModuleDto PurchasedModule { get; init; }
    public required DTOs.Modules.ModuleDto Module { get; init; }
}

public record class WorkshopUserContextDto
{
    public required UserDto User { get; init; }
    public required DTOs.Organizations.OrganizationDto Organization { get; init; }
    public required DTOs.Roles.RoleDto Role { get; init; }
    public required IReadOnlyList<PermissionDto> RolePermissions { get; init; }
    public required IReadOnlyList<WorkshopUserModuleViewDto> UserModules { get; init; }
}
