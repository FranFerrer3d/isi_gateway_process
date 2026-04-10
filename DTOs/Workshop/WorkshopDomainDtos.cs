using IsiGatewayProcess.DTOs.Actions;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Locations;
using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.DTOs.RolePermissions;
using IsiGatewayProcess.DTOs.Roles;
using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.DTOs.Workshop;

public record class WorkshopOrganizationTypeDto : EntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid? ParentId { get; init; }
}

public record class WorkshopPurchasedModuleDto : RegistrableEntityDto
{
    public Guid OrganizationId { get; init; }
    public Guid ModuleId { get; init; }
}

public record class WorkshopUserModuleDto : RegistrableEntityDto
{
    public Guid PurchasedModuleId { get; init; }
    public Guid UserId { get; init; }
    public bool Create { get; init; }
    public bool Read { get; init; }
    public bool Update { get; init; }
    public bool Delete { get; init; }
    public bool List { get; init; }
    public bool Deregistrated { get; init; }
}

public record class WorkshopStorageTypeDto : EntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid? ParentId { get; init; }
}

public record class WorkshopStorageDto : RegistrableEntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid? ParentId { get; init; }
    public Guid StorageTypeId { get; init; }
}

public record class WorkshopItemPhysicalStateDto : EntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}

public record class WorkshopItemNatureDto : EntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}

public record class WorkshopItemDto : RegistrableEntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid ItemPhysicalStateId { get; init; }
    public Guid ItemNatureId { get; init; }
}

public record class WorkshopCatalogueDto : RegistrableEntityDto
{
    public Guid ItemId { get; init; }
    public decimal Price { get; init; }
    public string? ImageUrl { get; init; }
}

public record class WorkshopReferenceTypeDto : EntityDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}

public record class WorkshopReferenceDto : EntityDto
{
    public Guid CatalogueId { get; init; }
    public Guid ReferenceTypeId { get; init; }
    public string Reference { get; init; } = default!;
}

public record class WorkshopItemQualityDto : EntityDto
{
    public Guid OrganizationId { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}

public record class WorkshopInventoryDto : RegistrableEntityDto
{
    public Guid CatalogueId { get; init; }
    public Guid StorageId { get; init; }
    public Guid ItemQualityId { get; init; }
    public decimal Quantity { get; init; }
}

public record class WorkshopPetitionStatusDto : EntityDto
{
    public string Code { get; init; } = default!;
    public string? Description { get; init; }
}

public record class WorkshopPetitionDto : RegistrableEntityDto
{
    public Guid PetitionaryUserId { get; init; }
    public Guid PetitionaryOrganizationId { get; init; }
    public Guid ReceiverOrganizationId { get; init; }
    public Guid StatusId { get; init; }
    public DateTimeOffset EstimatedTimeArrival { get; init; }
}

public record class WorkshopPetitionDetailDto : EntityDto
{
    public Guid PetitionId { get; init; }
    public Guid ItemId { get; init; }
    public decimal Quantity { get; init; }
    public decimal Amount { get; init; }
}

public record class WorkshopAuditDto : EntityDto
{
    public Guid ModuleId { get; init; }
    public Guid ActionId { get; init; }
    public Guid UserId { get; init; }
    public DateTimeOffset OperationTime { get; init; }
    public Guid AffectedElementId { get; init; }
    public string? AffectedElementInformation { get; init; }
}

public record class WorkshopSeedSnapshot
{
    public required IReadOnlyList<OrganizationDto> Organizations { get; init; }
    public required IReadOnlyList<LocationDto> Locations { get; init; }
    public required IReadOnlyList<ModuleDto> Modules { get; init; }
    public required IReadOnlyList<ActionDto> Actions { get; init; }
    public required IReadOnlyList<RoleDto> Roles { get; init; }
    public required IReadOnlyList<UserDto> Users { get; init; }
    public required IReadOnlyList<RolePermissionDto> RolePermissions { get; init; }
    public required IReadOnlyDictionary<Guid, string> PlainTextPasswords { get; init; }
    public required IReadOnlyList<WorkshopOrganizationTypeDto> OrganizationTypes { get; init; }
    public required IReadOnlyList<WorkshopPurchasedModuleDto> PurchasedModules { get; init; }
    public required IReadOnlyList<WorkshopUserModuleDto> UserModules { get; init; }
    public required IReadOnlyList<WorkshopStorageTypeDto> StorageTypes { get; init; }
    public required IReadOnlyList<WorkshopStorageDto> Storages { get; init; }
    public required IReadOnlyList<WorkshopItemPhysicalStateDto> ItemPhysicalStates { get; init; }
    public required IReadOnlyList<WorkshopItemNatureDto> ItemNatures { get; init; }
    public required IReadOnlyList<WorkshopItemDto> Items { get; init; }
    public required IReadOnlyList<WorkshopCatalogueDto> Catalogues { get; init; }
    public required IReadOnlyList<WorkshopReferenceTypeDto> ReferenceTypes { get; init; }
    public required IReadOnlyList<WorkshopReferenceDto> References { get; init; }
    public required IReadOnlyList<WorkshopItemQualityDto> ItemQualities { get; init; }
    public required IReadOnlyList<WorkshopInventoryDto> Inventories { get; init; }
    public required IReadOnlyList<WorkshopPetitionStatusDto> PetitionStatuses { get; init; }
    public required IReadOnlyList<WorkshopPetitionDto> Petitions { get; init; }
    public required IReadOnlyList<WorkshopPetitionDetailDto> PetitionDetails { get; init; }
    public required IReadOnlyList<WorkshopAuditDto> Audits { get; init; }
}
