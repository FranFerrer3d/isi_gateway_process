using IsiGatewayProcess.DTOs.Workshop;
using IsiGatewayProcess.Repositories;

namespace IsiGatewayProcess.Services;

public sealed class WorkshopReadService : IWorkshopReadService
{
    private readonly WorkshopMockDatabase _database;
    private readonly IUserRepository _userRepository;
    private readonly IPermissionService _permissionService;

    public WorkshopReadService(WorkshopMockDatabase database, IUserRepository userRepository, IPermissionService permissionService)
    {
        _database = database;
        _userRepository = userRepository;
        _permissionService = permissionService;
    }

    public Task<WorkshopLookupsDto> GetLookupsAsync()
    {
        var snapshot = _database.Snapshot;
        return Task.FromResult(new WorkshopLookupsDto
        {
            Organizations = snapshot.Organizations.OrderBy(item => item.Name).ToList(),
            Modules = snapshot.Modules.OrderBy(item => item.Name).ToList(),
            Actions = snapshot.Actions.OrderBy(item => item.Name).ToList(),
            Roles = snapshot.Roles.OrderBy(item => item.Code).ToList(),
            OrganizationTypes = snapshot.OrganizationTypes.OrderBy(item => item.Name).ToList(),
            StorageTypes = snapshot.StorageTypes.OrderBy(item => item.Name).ToList(),
            ItemPhysicalStates = snapshot.ItemPhysicalStates.OrderBy(item => item.Name).ToList(),
            ItemNatures = snapshot.ItemNatures.OrderBy(item => item.Name).ToList(),
            ReferenceTypes = snapshot.ReferenceTypes.OrderBy(item => item.Name).ToList(),
            ItemQualities = snapshot.ItemQualities.OrderBy(item => item.Name).ToList(),
            PetitionStatuses = snapshot.PetitionStatuses.OrderBy(item => item.Code).ToList(),
        });
    }

    public Task<WorkshopBootstrapDto> GetBootstrapAsync() =>
        Task.FromResult(new WorkshopBootstrapDto
        {
            Seed = _database.Snapshot,
            Catalogue = BuildCatalogue(),
            Inventory = BuildInventory(),
            Petitions = BuildPetitions(),
        });

    public Task<IReadOnlyList<WorkshopCatalogueEntryDto>> GetCatalogueAsync(Guid? itemId = null, Guid? catalogueId = null) => Task.FromResult(BuildCatalogue(itemId, catalogueId));

    public Task<IReadOnlyList<WorkshopInventoryEntryDto>> GetInventoryAsync(Guid? storageId = null, Guid? itemId = null, Guid? catalogueId = null) => Task.FromResult(BuildInventory(storageId, itemId, catalogueId));

    public Task<IReadOnlyList<WorkshopPetitionViewDto>> GetPetitionsAsync(string? statusCode = null, Guid? petitionaryOrganizationId = null, Guid? receiverOrganizationId = null) => Task.FromResult(BuildPetitions(statusCode, petitionaryOrganizationId, receiverOrganizationId));

    public Task<IReadOnlyList<WorkshopAuditViewDto>> GetAuditAsync()
    {
        var snapshot = _database.Snapshot;
        IReadOnlyList<WorkshopAuditViewDto> rows = snapshot.Audits
            .OrderByDescending(item => item.OperationTime)
            .Select(audit => new WorkshopAuditViewDto
            {
                Audit = audit,
                Module = snapshot.Modules.First(module => module.Id == audit.ModuleId),
                Action = snapshot.Actions.First(action => action.Id == audit.ActionId),
                User = snapshot.Users.First(user => user.Id == audit.UserId),
            })
            .ToList();
        return Task.FromResult(rows);
    }

    public async Task<WorkshopUserContextDto?> GetUserContextAsync(Guid userId)
    {
        var user = await _userRepository.GetAsync(userId);
        if (user is null)
        {
            return null;
        }

        var snapshot = _database.Snapshot;
        var organization = snapshot.Organizations.FirstOrDefault(item => item.Id == user.OrganizationId);
        var role = snapshot.Roles.FirstOrDefault(item => item.Id == user.UserRoleId);
        if (organization is null || role is null)
        {
            return null;
        }

        var permissions = await _permissionService.GetPermissionsForUserAsync(user.Id);
        var userModules = snapshot.UserModules
            .Where(item => item.UserId == user.Id)
            .Select(item =>
            {
                var purchasedModule = snapshot.PurchasedModules.First(entry => entry.Id == item.PurchasedModuleId);
                var module = snapshot.Modules.First(entry => entry.Id == purchasedModule.ModuleId);
                return new WorkshopUserModuleViewDto
                {
                    Assignment = item,
                    PurchasedModule = purchasedModule,
                    Module = module,
                };
            })
            .OrderBy(item => item.Module.Name)
            .ToList();

        return new WorkshopUserContextDto
        {
            User = user,
            Organization = organization,
            Role = role,
            RolePermissions = permissions,
            UserModules = userModules,
        };
    }

    private IReadOnlyList<WorkshopCatalogueEntryDto> BuildCatalogue(Guid? itemId = null, Guid? catalogueId = null)
    {
        var snapshot = _database.Snapshot;
        return snapshot.Catalogues
            .Where(catalogue => !catalogueId.HasValue || catalogue.Id == catalogueId.Value)
            .Where(catalogue => !itemId.HasValue || catalogue.ItemId == itemId.Value)
            .Select(catalogue =>
            {
                var item = snapshot.Items.First(entry => entry.Id == catalogue.ItemId);
                var stock = snapshot.Inventories
                    .Where(entry => entry.CatalogueId == catalogue.Id)
                    .Select(entry =>
                    {
                        var storage = snapshot.Storages.First(item => item.Id == entry.StorageId);
                        var storageType = snapshot.StorageTypes.First(item => item.Id == storage.StorageTypeId);
                        var quality = snapshot.ItemQualities.First(item => item.Id == entry.ItemQualityId);
                        return new WorkshopInventorySummaryDto
                        {
                            Inventory = entry,
                            Storage = storage,
                            StorageType = storageType,
                            Quality = quality,
                        };
                    })
                    .OrderBy(entry => entry.Storage.Name)
                    .ToList();

                return new WorkshopCatalogueEntryDto
                {
                    Catalogue = catalogue,
                    Item = item,
                    References = BuildReferences(catalogue.Id),
                    Stock = stock,
                    TotalQuantity = stock.Sum(entry => entry.Inventory.Quantity),
                };
            })
            .OrderBy(entry => entry.Item.Name)
            .ToList();
    }

    private IReadOnlyList<WorkshopInventoryEntryDto> BuildInventory(Guid? storageId = null, Guid? itemId = null, Guid? catalogueId = null)
    {
        var snapshot = _database.Snapshot;
        return snapshot.Inventories
            .Where(inventory => !storageId.HasValue || inventory.StorageId == storageId.Value)
            .Where(inventory => !catalogueId.HasValue || inventory.CatalogueId == catalogueId.Value)
            .OrderByDescending(item => item.Quantity)
            .Select(inventory =>
            {
                var catalogue = snapshot.Catalogues.First(item => item.Id == inventory.CatalogueId);
                var item = snapshot.Items.First(entry => entry.Id == catalogue.ItemId);
                if (itemId.HasValue && item.Id != itemId.Value)
                {
                    return null;
                }
                var storage = snapshot.Storages.First(entry => entry.Id == inventory.StorageId);
                var storageType = snapshot.StorageTypes.First(entry => entry.Id == storage.StorageTypeId);
                var quality = snapshot.ItemQualities.First(entry => entry.Id == inventory.ItemQualityId);

                return new WorkshopInventoryEntryDto
                {
                    Inventory = inventory,
                    Catalogue = catalogue,
                    Item = item,
                    Storage = storage,
                    StorageType = storageType,
                    Quality = quality,
                    References = BuildReferences(catalogue.Id),
                };
            })
            .Where(entry => entry is not null)
            .Select(entry => entry!)
            .ToList();
    }

    private IReadOnlyList<WorkshopPetitionViewDto> BuildPetitions(string? statusCode = null, Guid? petitionaryOrganizationId = null, Guid? receiverOrganizationId = null)
    {
        var snapshot = _database.Snapshot;
        return snapshot.Petitions
            .Where(petition => !petitionaryOrganizationId.HasValue || petition.PetitionaryOrganizationId == petitionaryOrganizationId.Value)
            .Where(petition => !receiverOrganizationId.HasValue || petition.ReceiverOrganizationId == receiverOrganizationId.Value)
            .OrderByDescending(item => item.RegistrationDate)
            .Select(petition => new WorkshopPetitionViewDto
            {
                Petition = petition,
                PetitionaryUser = snapshot.Users.First(user => user.Id == petition.PetitionaryUserId),
                PetitionaryOrganization = snapshot.Organizations.First(org => org.Id == petition.PetitionaryOrganizationId),
                ReceiverOrganization = snapshot.Organizations.First(org => org.Id == petition.ReceiverOrganizationId),
                Status = snapshot.PetitionStatuses.First(status => status.Id == petition.StatusId),
                Details = snapshot.PetitionDetails
                    .Where(detail => detail.PetitionId == petition.Id)
                    .Select(detail => new WorkshopPetitionDetailViewDto
                    {
                        Detail = detail,
                        Item = snapshot.Items.First(item => item.Id == detail.ItemId),
                    })
                    .ToList(),
            })
            .Where(view => string.IsNullOrWhiteSpace(statusCode) || string.Equals(view.Status.Code, statusCode, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    private IReadOnlyList<WorkshopReferenceViewDto> BuildReferences(Guid catalogueId)
    {
        var snapshot = _database.Snapshot;
        return snapshot.References
            .Where(item => item.CatalogueId == catalogueId)
            .Select(reference => new WorkshopReferenceViewDto
            {
                Reference = reference,
                ReferenceType = snapshot.ReferenceTypes.First(type => type.Id == reference.ReferenceTypeId),
            })
            .OrderBy(item => item.ReferenceType.Name)
            .ThenBy(item => item.Reference.Reference)
            .ToList();
    }
}
