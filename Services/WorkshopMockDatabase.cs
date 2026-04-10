using IsiGatewayProcess.DTOs.Actions;
using IsiGatewayProcess.DTOs.Locations;
using IsiGatewayProcess.DTOs.Modules;
using IsiGatewayProcess.DTOs.Organizations;
using IsiGatewayProcess.DTOs.RolePermissions;
using IsiGatewayProcess.DTOs.Roles;
using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Workshop;

namespace IsiGatewayProcess.Services;

public sealed class WorkshopMockDatabase
{
    public WorkshopMockDatabase()
    {
        Snapshot = BuildSnapshot();
    }

    public WorkshopSeedSnapshot Snapshot { get; }

    private static WorkshopSeedSnapshot BuildSnapshot()
    {
        static Guid G(string value) => Guid.Parse(value);

        var registeredOn = new DateTimeOffset(2026, 01, 13, 7, 30, 0, TimeSpan.Zero);
        var activeSince = new DateTimeOffset(2026, 01, 20, 8, 0, 0, TimeSpan.Zero);

        var orgTypeHoldingId = G("11111111-1111-1111-1111-111111111001");
        var orgTypeWorkshopId = G("11111111-1111-1111-1111-111111111002");
        var orgTypeFleetId = G("11111111-1111-1111-1111-111111111003");
        var orgTypeSupplierId = G("11111111-1111-1111-1111-111111111004");
        var cadiaGroupId = G("20000000-0000-0000-0000-000000000001");
        var madridWorkshopId = G("20000000-0000-0000-0000-000000000002");
        var transIberiaId = G("20000000-0000-0000-0000-000000000003");
        var atlasSupplyId = G("20000000-0000-0000-0000-000000000004");
        var hqLocationId = G("21000000-0000-0000-0000-000000000001");
        var madridDockId = G("21000000-0000-0000-0000-000000000002");
        var toledoBaseId = G("21000000-0000-0000-0000-000000000003");
        var organizationModuleId = G("22000000-0000-0000-0000-000000000001");
        var usersModuleId = G("22000000-0000-0000-0000-000000000002");
        var inventoryModuleId = G("22000000-0000-0000-0000-000000000003");
        var channelModuleId = G("22000000-0000-0000-0000-000000000004");
        var auditModuleId = G("22000000-0000-0000-0000-000000000005");
        var actionCreateId = G("23000000-0000-0000-0000-000000000001");
        var actionReadId = G("23000000-0000-0000-0000-000000000002");
        var actionUpdateId = G("23000000-0000-0000-0000-000000000003");
        var actionDeleteId = G("23000000-0000-0000-0000-000000000004");
        var actionListId = G("23000000-0000-0000-0000-000000000005");
        var actionDeregisterId = G("23000000-0000-0000-0000-000000000006");
        var workshopManagerRoleId = G("24000000-0000-0000-0000-000000000001");
        var warehouseLeadRoleId = G("24000000-0000-0000-0000-000000000002");
        var fleetCoordinatorRoleId = G("24000000-0000-0000-0000-000000000003");
        var javierUserId = G("25000000-0000-0000-0000-000000000001");
        var martaUserId = G("25000000-0000-0000-0000-000000000002");
        var alvaroUserId = G("25000000-0000-0000-0000-000000000003");
        var purchasedWorkshopInventoryId = G("26000000-0000-0000-0000-000000000001");
        var purchasedWorkshopChannelId = G("26000000-0000-0000-0000-000000000002");
        var purchasedWorkshopAuditId = G("26000000-0000-0000-0000-000000000003");
        var purchasedFleetInventoryId = G("26000000-0000-0000-0000-000000000004");
        var purchasedFleetChannelId = G("26000000-0000-0000-0000-000000000005");
        var storageTypeWarehouseId = G("27000000-0000-0000-0000-000000000001");
        var storageTypeRackId = G("27000000-0000-0000-0000-000000000002");
        var storageTypeTankId = G("27000000-0000-0000-0000-000000000003");
        var mainWarehouseId = G("28000000-0000-0000-0000-000000000001");
        var filterRackId = G("28000000-0000-0000-0000-000000000002");
        var oilTankId = G("28000000-0000-0000-0000-000000000003");
        var itemStateNewId = G("29000000-0000-0000-0000-000000000001");
        var itemStateConsumableId = G("29000000-0000-0000-0000-000000000002");
        var itemNatureSpareId = G("29100000-0000-0000-0000-000000000001");
        var itemNatureOilId = G("29100000-0000-0000-0000-000000000002");
        var itemOilFilterId = G("29200000-0000-0000-0000-000000000001");
        var itemFuelFilterId = G("29200000-0000-0000-0000-000000000002");
        var itemEngineOilId = G("29200000-0000-0000-0000-000000000003");
        var itemBrakePadsId = G("29200000-0000-0000-0000-000000000004");
        var itemBatteryId = G("29200000-0000-0000-0000-000000000005");
        var catalogueOilFilterId = G("29300000-0000-0000-0000-000000000001");
        var catalogueFuelFilterId = G("29300000-0000-0000-0000-000000000002");
        var catalogueEngineOilId = G("29300000-0000-0000-0000-000000000003");
        var catalogueBrakePadsId = G("29300000-0000-0000-0000-000000000004");
        var catalogueBatteryId = G("29300000-0000-0000-0000-000000000005");
        var refTypeOemId = G("29400000-0000-0000-0000-000000000001");
        var refTypeInternalId = G("29400000-0000-0000-0000-000000000002");
        var refTypeSupplierId = G("29400000-0000-0000-0000-000000000003");
        var qualityNewId = G("29500000-0000-0000-0000-000000000001");
        var qualityBulkId = G("29500000-0000-0000-0000-000000000002");
        var statusRequestedId = G("29600000-0000-0000-0000-000000000002");
        var statusApprovedId = G("29600000-0000-0000-0000-000000000003");
        var petitionFilterKitId = G("29700000-0000-0000-0000-000000000001");
        var petitionEmergencyOrderId = G("29700000-0000-0000-0000-000000000002");

        var organizations = new[]
        {
            new OrganizationDto { Id = cadiaGroupId, Name = "Cadia Mobility Group", Description = "Matriz del gateway mock para alquiler y mantenimiento pesado.", OrganizationTypeId = orgTypeHoldingId, CompanyId = null, Address = "Av. de la Industria 14", City = "Madrid", Region = "Madrid", Country = "Spain", Email = "ops@cadia-group.test", PhoneNumber = "+34 910 000 001", RegistrationDate = registeredOn, DeregistrationDate = null },
            new OrganizationDto { Id = madridWorkshopId, Name = "Cadia Heavy Services Madrid", Description = "Taller central de recambio, mantenimiento y preparación de tractoras.", OrganizationTypeId = orgTypeWorkshopId, CompanyId = cadiaGroupId, Address = "Calle Fundición 8", City = "Coslada", Region = "Madrid", Country = "Spain", Email = "taller.madrid@cadia.test", PhoneNumber = "+34 910 000 010", RegistrationDate = registeredOn.AddDays(1), DeregistrationDate = null },
            new OrganizationDto { Id = transIberiaId, Name = "TransIberia Logistics", Description = "Cliente operador de flota para distribución nacional.", OrganizationTypeId = orgTypeFleetId, CompanyId = null, Address = "Pol. La Sagra 21", City = "Toledo", Region = "Castilla-La Mancha", Country = "Spain", Email = "mantenimiento@transiberia.test", PhoneNumber = "+34 925 000 120", RegistrationDate = registeredOn.AddDays(2), DeregistrationDate = null },
            new OrganizationDto { Id = atlasSupplyId, Name = "Atlas Industrial Supply", Description = "Proveedor mock de recambio OEM y lubricantes.", OrganizationTypeId = orgTypeSupplierId, CompanyId = null, Address = "Ctra. Logística 44", City = "Zaragoza", Region = "Aragon", Country = "Spain", Email = "ventas@atlas-supply.test", PhoneNumber = "+34 976 000 440", RegistrationDate = registeredOn.AddDays(3), DeregistrationDate = null },
        };

        var snapshot = new WorkshopSeedSnapshot
        {
            Organizations = organizations,
            Locations = new[]
            {
                new LocationDto { Id = hqLocationId, OrganizationId = cadiaGroupId, Name = "Corporate HQ", Description = "Oficinas centrales, compras y coordinación.", Address = "Av. de la Industria 14", City = "Madrid", Region = "Madrid", Country = "Spain", RegistrationDate = activeSince, DeregistrationDate = null },
                new LocationDto { Id = madridDockId, OrganizationId = madridWorkshopId, Name = "Taller Madrid", Description = "Taller principal con recepción, boxes y almacén.", Address = "Calle Fundición 8", City = "Coslada", Region = "Madrid", Country = "Spain", RegistrationDate = activeSince, DeregistrationDate = null },
                new LocationDto { Id = toledoBaseId, OrganizationId = transIberiaId, Name = "Base Toledo", Description = "Base operativa de flota para rutas centro.", Address = "Pol. La Sagra 21", City = "Toledo", Region = "Castilla-La Mancha", Country = "Spain", RegistrationDate = activeSince, DeregistrationDate = null },
            },
            Modules = new[]
            {
                new ModuleDto { Id = organizationModuleId, Code = "organization", Name = "Organization", Description = "Organizaciones, tipos y módulos contratados." },
                new ModuleDto { Id = usersModuleId, Code = "users", Name = "Users", Description = "Usuarios y permisos operativos." },
                new ModuleDto { Id = inventoryModuleId, Code = "inventory", Name = "Inventory", Description = "Recambio, catálogo y stock." },
                new ModuleDto { Id = channelModuleId, Code = "channel", Name = "Channel", Description = "Solicitudes de taller y expedición." },
                new ModuleDto { Id = auditModuleId, Code = "audit", Name = "Audit", Description = "Trazabilidad de operaciones." },
            },
            Actions = new[]
            {
                new ActionDto { Id = actionCreateId, Code = "create", Name = "Create", Description = "Alta de recurso." },
                new ActionDto { Id = actionReadId, Code = "read", Name = "Read", Description = "Consulta de detalle." },
                new ActionDto { Id = actionUpdateId, Code = "update", Name = "Update", Description = "Modificación de recurso." },
                new ActionDto { Id = actionDeleteId, Code = "delete", Name = "Delete", Description = "Borrado lógico o físico." },
                new ActionDto { Id = actionListId, Code = "list", Name = "List", Description = "Consulta agregada." },
                new ActionDto { Id = actionDeregisterId, Code = "deregister", Name = "Deregister", Description = "Baja operativa." },
            },
            Roles = new[]
            {
                new RoleDto { Id = workshopManagerRoleId, OrganizationId = madridWorkshopId, Code = "WORKSHOP_MANAGER", Description = "Responsable de taller y coordinación de mantenimiento." },
                new RoleDto { Id = warehouseLeadRoleId, OrganizationId = madridWorkshopId, Code = "WAREHOUSE_LEAD", Description = "Responsable de almacén y preparación de recambio." },
                new RoleDto { Id = fleetCoordinatorRoleId, OrganizationId = transIberiaId, Code = "FLEET_COORDINATOR", Description = "Coordinador de flota y peticiones de intervención." },
            },
            Users = new[]
            {
                new UserDto { Id = javierUserId, OrganizationId = madridWorkshopId, LocationId = madridDockId, UserRoleId = workshopManagerRoleId, UserName = "rguilliman", Name = "Roboute", LastName = "Guilliman", Email = "rguilliman@cadia.test", RegistrationDate = activeSince, DeregistrationDate = null },
                new UserDto { Id = martaUserId, OrganizationId = madridWorkshopId, LocationId = madridDockId, UserRoleId = warehouseLeadRoleId, UserName = "kcruz", Name = "Katherine", LastName = "Cruz", Email = "kcruz@cadia.test", RegistrationDate = activeSince.AddHours(2), DeregistrationDate = null },
                new UserDto { Id = alvaroUserId, OrganizationId = transIberiaId, LocationId = toledoBaseId, UserRoleId = fleetCoordinatorRoleId, UserName = "lruss", Name = "Leman", LastName = "Russ", Email = "lruss@transiberia.test", RegistrationDate = activeSince.AddDays(1), DeregistrationDate = null },
            },
            RolePermissions = BuildRolePermissions(workshopManagerRoleId, warehouseLeadRoleId, fleetCoordinatorRoleId, organizationModuleId, usersModuleId, inventoryModuleId, channelModuleId, auditModuleId, actionCreateId, actionReadId, actionUpdateId, actionListId, actionDeregisterId),
            PlainTextPasswords = new Dictionary<Guid, string> { [javierUserId] = "rguilliman", [martaUserId] = "kcruz", [alvaroUserId] = "lruss" },
            OrganizationTypes = new[]
            {
                new WorkshopOrganizationTypeDto { Id = orgTypeHoldingId, Name = "Holding", Description = "Cabecera corporativa.", ParentId = null },
                new WorkshopOrganizationTypeDto { Id = orgTypeWorkshopId, Name = "Workshop Branch", Description = "Taller con almacén y boxes.", ParentId = orgTypeHoldingId },
                new WorkshopOrganizationTypeDto { Id = orgTypeFleetId, Name = "Fleet Operator", Description = "Cliente con flota pesada.", ParentId = null },
                new WorkshopOrganizationTypeDto { Id = orgTypeSupplierId, Name = "Supplier", Description = "Proveedor de recambio.", ParentId = null },
            },
            PurchasedModules = new[]
            {
                new WorkshopPurchasedModuleDto { Id = purchasedWorkshopInventoryId, OrganizationId = madridWorkshopId, ModuleId = inventoryModuleId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopPurchasedModuleDto { Id = purchasedWorkshopChannelId, OrganizationId = madridWorkshopId, ModuleId = channelModuleId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopPurchasedModuleDto { Id = purchasedWorkshopAuditId, OrganizationId = madridWorkshopId, ModuleId = auditModuleId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopPurchasedModuleDto { Id = purchasedFleetInventoryId, OrganizationId = transIberiaId, ModuleId = inventoryModuleId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopPurchasedModuleDto { Id = purchasedFleetChannelId, OrganizationId = transIberiaId, ModuleId = channelModuleId, RegistrationDate = activeSince, DeregistrationDate = null },
            },
            UserModules = new[]
            {
                new WorkshopUserModuleDto { Id = G("26100000-0000-0000-0000-000000000001"), PurchasedModuleId = purchasedWorkshopInventoryId, UserId = javierUserId, Create = true, Read = true, Update = true, Delete = false, List = true, Deregistrated = true, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopUserModuleDto { Id = G("26100000-0000-0000-0000-000000000002"), PurchasedModuleId = purchasedWorkshopChannelId, UserId = javierUserId, Create = true, Read = true, Update = true, Delete = false, List = true, Deregistrated = true, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopUserModuleDto { Id = G("26100000-0000-0000-0000-000000000003"), PurchasedModuleId = purchasedWorkshopAuditId, UserId = javierUserId, Create = false, Read = true, Update = false, Delete = false, List = true, Deregistrated = false, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopUserModuleDto { Id = G("26100000-0000-0000-0000-000000000004"), PurchasedModuleId = purchasedWorkshopInventoryId, UserId = martaUserId, Create = true, Read = true, Update = true, Delete = false, List = true, Deregistrated = true, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopUserModuleDto { Id = G("26100000-0000-0000-0000-000000000005"), PurchasedModuleId = purchasedFleetChannelId, UserId = alvaroUserId, Create = true, Read = true, Update = true, Delete = false, List = true, Deregistrated = false, RegistrationDate = activeSince, DeregistrationDate = null },
            },
            StorageTypes = new[]
            {
                new WorkshopStorageTypeDto { Id = storageTypeWarehouseId, Name = "Warehouse", Description = "Nave principal.", ParentId = null },
                new WorkshopStorageTypeDto { Id = storageTypeRackId, Name = "Rack", Description = "Estantería o bloque de picking.", ParentId = storageTypeWarehouseId },
                new WorkshopStorageTypeDto { Id = storageTypeTankId, Name = "Tank", Description = "Depósito de fluidos.", ParentId = storageTypeWarehouseId },
            },
            Storages = new[]
            {
                new WorkshopStorageDto { Id = mainWarehouseId, Name = "Main Spare Parts Warehouse", Description = "Nave principal de recambio del taller de Madrid.", ParentId = null, StorageTypeId = storageTypeWarehouseId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopStorageDto { Id = filterRackId, Name = "Filter Rack A1", Description = "Filtros de aceite y combustible.", ParentId = mainWarehouseId, StorageTypeId = storageTypeRackId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopStorageDto { Id = oilTankId, Name = "Lubricants Tank C1", Description = "Bidones y aceites de reposición rápida.", ParentId = mainWarehouseId, StorageTypeId = storageTypeTankId, RegistrationDate = activeSince, DeregistrationDate = null },
            },
            ItemPhysicalStates = new[]
            {
                new WorkshopItemPhysicalStateDto { Id = itemStateNewId, Name = "New", Description = "Material nuevo listo para montaje." },
                new WorkshopItemPhysicalStateDto { Id = itemStateConsumableId, Name = "Consumable", Description = "Material fungible o fluido." },
            },
            ItemNatures = new[]
            {
                new WorkshopItemNatureDto { Id = itemNatureSpareId, Name = "Spare Part", Description = "Componente de recambio." },
                new WorkshopItemNatureDto { Id = itemNatureOilId, Name = "Lubricant", Description = "Aceites, grasas y fluidos técnicos." },
            },
            Items = new[]
            {
                new WorkshopItemDto { Id = itemOilFilterId, Name = "Oil Filter LF9009", Description = "Filtro de aceite para tractora Volvo/Renault.", ItemPhysicalStateId = itemStateNewId, ItemNatureId = itemNatureSpareId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopItemDto { Id = itemFuelFilterId, Name = "Fuel Filter Water Separator", Description = "Filtro de gasóleo con separador de agua.", ItemPhysicalStateId = itemStateNewId, ItemNatureId = itemNatureSpareId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopItemDto { Id = itemEngineOilId, Name = "15W40 Engine Oil 20L", Description = "Aceite mineral para intervalos de servicio intensivo.", ItemPhysicalStateId = itemStateConsumableId, ItemNatureId = itemNatureOilId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopItemDto { Id = itemBrakePadsId, Name = "Front Axle Brake Pad Kit", Description = "Juego de pastillas para eje delantero de tractora.", ItemPhysicalStateId = itemStateNewId, ItemNatureId = itemNatureSpareId, RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopItemDto { Id = itemBatteryId, Name = "180 Ah Battery 12V", Description = "Batería de arranque reforzada para camión pesado.", ItemPhysicalStateId = itemStateNewId, ItemNatureId = itemNatureSpareId, RegistrationDate = activeSince, DeregistrationDate = null },
            },
            Catalogues = new[]
            {
                new WorkshopCatalogueDto { Id = catalogueOilFilterId, ItemId = itemOilFilterId, Price = 26.40m, ImageUrl = "https://cdn.cadia.mock/catalogue/oil-filter-lf9009.jpg", RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopCatalogueDto { Id = catalogueFuelFilterId, ItemId = itemFuelFilterId, Price = 31.75m, ImageUrl = "https://cdn.cadia.mock/catalogue/fuel-filter-water-separator.jpg", RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopCatalogueDto { Id = catalogueEngineOilId, ItemId = itemEngineOilId, Price = 89.00m, ImageUrl = "https://cdn.cadia.mock/catalogue/engine-oil-15w40-20l.jpg", RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopCatalogueDto { Id = catalogueBrakePadsId, ItemId = itemBrakePadsId, Price = 148.90m, ImageUrl = "https://cdn.cadia.mock/catalogue/brake-pad-kit-front-axle.jpg", RegistrationDate = activeSince, DeregistrationDate = null },
                new WorkshopCatalogueDto { Id = catalogueBatteryId, ItemId = itemBatteryId, Price = 219.00m, ImageUrl = "https://cdn.cadia.mock/catalogue/battery-180ah-12v.jpg", RegistrationDate = activeSince, DeregistrationDate = null },
            },
            ReferenceTypes = new[]
            {
                new WorkshopReferenceTypeDto { Id = refTypeOemId, Name = "OEM", Description = "Referencia del fabricante." },
                new WorkshopReferenceTypeDto { Id = refTypeInternalId, Name = "Internal", Description = "Código interno de taller." },
                new WorkshopReferenceTypeDto { Id = refTypeSupplierId, Name = "Supplier", Description = "Referencia comercial del proveedor." },
            },
            References = new[]
            {
                Ref("29410000-0000-0000-0000-000000000001", catalogueOilFilterId, refTypeOemId, "LF9009"),
                Ref("29410000-0000-0000-0000-000000000002", catalogueOilFilterId, refTypeInternalId, "CAD-FILT-001"),
                Ref("29410000-0000-0000-0000-000000000003", catalogueFuelFilterId, refTypeSupplierId, "ATL-FUEL-778"),
                Ref("29410000-0000-0000-0000-000000000004", catalogueEngineOilId, refTypeInternalId, "CAD-OIL-20L"),
                Ref("29410000-0000-0000-0000-000000000005", catalogueBrakePadsId, refTypeOemId, "K0945-AXF"),
                Ref("29410000-0000-0000-0000-000000000006", catalogueBatteryId, refTypeInternalId, "CAD-BATT-180"),
            },
            ItemQualities = new[]
            {
                new WorkshopItemQualityDto { Id = qualityNewId, OrganizationId = madridWorkshopId, Name = "New", Description = "Stock apto para montaje directo." },
                new WorkshopItemQualityDto { Id = qualityBulkId, OrganizationId = madridWorkshopId, Name = "Bulk", Description = "Consumible en granel o volumen." },
            },
            Inventories = new[]
            {
                Stock("29510000-0000-0000-0000-000000000001", catalogueOilFilterId, filterRackId, qualityNewId, 48m, activeSince),
                Stock("29510000-0000-0000-0000-000000000002", catalogueFuelFilterId, filterRackId, qualityNewId, 32m, activeSince),
                Stock("29510000-0000-0000-0000-000000000003", catalogueEngineOilId, oilTankId, qualityBulkId, 18m, activeSince),
                Stock("29510000-0000-0000-0000-000000000004", catalogueBrakePadsId, mainWarehouseId, qualityNewId, 14m, activeSince),
                Stock("29510000-0000-0000-0000-000000000005", catalogueBatteryId, mainWarehouseId, qualityNewId, 12m, activeSince),
            },
            PetitionStatuses = new[]
            {
                new WorkshopPetitionStatusDto { Id = statusRequestedId, Code = "REQUESTED", Description = "Solicitud enviada y pendiente de aprobación." },
                new WorkshopPetitionStatusDto { Id = statusApprovedId, Code = "APPROVED", Description = "Solicitud aprobada y reservada." },
            },
            Petitions = new[]
            {
                new WorkshopPetitionDto { Id = petitionFilterKitId, PetitionaryUserId = alvaroUserId, PetitionaryOrganizationId = transIberiaId, ReceiverOrganizationId = madridWorkshopId, StatusId = statusRequestedId, RegistrationDate = activeSince.AddDays(10), DeregistrationDate = null, EstimatedTimeArrival = activeSince.AddDays(11).AddHours(6) },
                new WorkshopPetitionDto { Id = petitionEmergencyOrderId, PetitionaryUserId = javierUserId, PetitionaryOrganizationId = madridWorkshopId, ReceiverOrganizationId = atlasSupplyId, StatusId = statusApprovedId, RegistrationDate = activeSince.AddDays(12), DeregistrationDate = null, EstimatedTimeArrival = activeSince.AddDays(14) },
            },
            PetitionDetails = new[]
            {
                new WorkshopPetitionDetailDto { Id = G("29710000-0000-0000-0000-000000000001"), PetitionId = petitionFilterKitId, ItemId = itemOilFilterId, Quantity = 8m, Amount = 211.20m },
                new WorkshopPetitionDetailDto { Id = G("29710000-0000-0000-0000-000000000002"), PetitionId = petitionFilterKitId, ItemId = itemFuelFilterId, Quantity = 8m, Amount = 254.00m },
                new WorkshopPetitionDetailDto { Id = G("29710000-0000-0000-0000-000000000003"), PetitionId = petitionFilterKitId, ItemId = itemEngineOilId, Quantity = 4m, Amount = 356.00m },
                new WorkshopPetitionDetailDto { Id = G("29710000-0000-0000-0000-000000000004"), PetitionId = petitionEmergencyOrderId, ItemId = itemBrakePadsId, Quantity = 2m, Amount = 297.80m },
            },
            Audits = new[]
            {
                new WorkshopAuditDto { Id = G("29800000-0000-0000-0000-000000000001"), ModuleId = inventoryModuleId, ActionId = actionUpdateId, UserId = martaUserId, OperationTime = activeSince.AddDays(9).AddHours(2), AffectedElementId = catalogueBrakePadsId, AffectedElementInformation = "Brake pad stock adjusted after workshop count." },
                new WorkshopAuditDto { Id = G("29800000-0000-0000-0000-000000000002"), ModuleId = channelModuleId, ActionId = actionCreateId, UserId = alvaroUserId, OperationTime = activeSince.AddDays(10).AddHours(1), AffectedElementId = petitionFilterKitId, AffectedElementInformation = "Preventive maintenance request for three Volvo FH units." },
            },
        };

        ValidateSnapshot(snapshot);
        return snapshot;
    }

    private static IReadOnlyList<RolePermissionDto> BuildRolePermissions(Guid workshopManagerRoleId, Guid warehouseLeadRoleId, Guid fleetCoordinatorRoleId, Guid organizationModuleId, Guid usersModuleId, Guid inventoryModuleId, Guid channelModuleId, Guid auditModuleId, Guid actionCreateId, Guid actionReadId, Guid actionUpdateId, Guid actionListId, Guid actionDeregisterId)
    {
        var permissions = new List<RolePermissionDto>();
        var seed = 1;
        permissions.AddRange(CreatePermissions(workshopManagerRoleId, organizationModuleId, ref seed, actionReadId, actionListId));
        permissions.AddRange(CreatePermissions(workshopManagerRoleId, usersModuleId, ref seed, actionReadId, actionListId, actionUpdateId));
        permissions.AddRange(CreatePermissions(workshopManagerRoleId, inventoryModuleId, ref seed, actionCreateId, actionReadId, actionUpdateId, actionListId, actionDeregisterId));
        permissions.AddRange(CreatePermissions(workshopManagerRoleId, channelModuleId, ref seed, actionCreateId, actionReadId, actionUpdateId, actionListId));
        permissions.AddRange(CreatePermissions(workshopManagerRoleId, auditModuleId, ref seed, actionReadId, actionListId));
        permissions.AddRange(CreatePermissions(warehouseLeadRoleId, inventoryModuleId, ref seed, actionCreateId, actionReadId, actionUpdateId, actionListId));
        permissions.AddRange(CreatePermissions(warehouseLeadRoleId, channelModuleId, ref seed, actionReadId, actionUpdateId, actionListId));
        permissions.AddRange(CreatePermissions(fleetCoordinatorRoleId, inventoryModuleId, ref seed, actionReadId, actionListId));
        permissions.AddRange(CreatePermissions(fleetCoordinatorRoleId, channelModuleId, ref seed, actionCreateId, actionReadId, actionUpdateId, actionListId));
        return permissions;
    }

    private static IReadOnlyList<RolePermissionDto> CreatePermissions(Guid roleId, Guid moduleId, ref int seed, params Guid[] actionIds)
    {
        var permissions = new List<RolePermissionDto>();
        foreach (var actionId in actionIds)
        {
            permissions.Add(new RolePermissionDto
            {
                Id = Guid.Parse($"2f000000-0000-0000-0000-{seed.ToString("D12")}"),
                RoleId = roleId,
                ModuleId = moduleId,
                ActionId = actionId,
            });
            seed++;
        }

        return permissions;
    }

    private static WorkshopReferenceDto Ref(string id, Guid catalogueId, Guid referenceTypeId, string value) =>
        new() { Id = Guid.Parse(id), CatalogueId = catalogueId, ReferenceTypeId = referenceTypeId, Reference = value };

    private static WorkshopInventoryDto Stock(string id, Guid catalogueId, Guid storageId, Guid qualityId, decimal quantity, DateTimeOffset registrationDate) =>
        new() { Id = Guid.Parse(id), CatalogueId = catalogueId, StorageId = storageId, ItemQualityId = qualityId, Quantity = quantity, RegistrationDate = registrationDate, DeregistrationDate = null };

    private static void ValidateSnapshot(WorkshopSeedSnapshot snapshot)
    {
        EnsureUnique(snapshot.Organizations.Select(item => item.Id), "organizations");
        EnsureUnique(snapshot.Locations.Select(item => item.Id), "locations");
        EnsureUnique(snapshot.Modules.Select(item => item.Id), "modules");
        EnsureUnique(snapshot.Actions.Select(item => item.Id), "actions");
        EnsureUnique(snapshot.Roles.Select(item => item.Id), "roles");
        EnsureUnique(snapshot.Users.Select(item => item.Id), "users");
        EnsureUnique(snapshot.RolePermissions.Select(item => item.Id), "role permissions");
        EnsureUnique(snapshot.OrganizationTypes.Select(item => item.Id), "organization types");
        EnsureUnique(snapshot.PurchasedModules.Select(item => item.Id), "purchased modules");
        EnsureUnique(snapshot.UserModules.Select(item => item.Id), "user modules");
        EnsureUnique(snapshot.StorageTypes.Select(item => item.Id), "storage types");
        EnsureUnique(snapshot.Storages.Select(item => item.Id), "storages");
        EnsureUnique(snapshot.Items.Select(item => item.Id), "items");
        EnsureUnique(snapshot.Catalogues.Select(item => item.Id), "catalogues");
        EnsureUnique(snapshot.References.Select(item => item.Id), "references");
        EnsureUnique(snapshot.ItemQualities.Select(item => item.Id), "item qualities");
        EnsureUnique(snapshot.Inventories.Select(item => item.Id), "inventories");
        EnsureUnique(snapshot.PetitionStatuses.Select(item => item.Id), "petition statuses");
        EnsureUnique(snapshot.Petitions.Select(item => item.Id), "petitions");
        EnsureUnique(snapshot.PetitionDetails.Select(item => item.Id), "petition details");
        EnsureUnique(snapshot.Audits.Select(item => item.Id), "audits");

        var organizationIds = snapshot.Organizations.Select(item => item.Id).ToHashSet();
        var locationIds = snapshot.Locations.Select(item => item.Id).ToHashSet();
        var moduleIds = snapshot.Modules.Select(item => item.Id).ToHashSet();
        var actionIds = snapshot.Actions.Select(item => item.Id).ToHashSet();
        var roleIds = snapshot.Roles.Select(item => item.Id).ToHashSet();
        var userIds = snapshot.Users.Select(item => item.Id).ToHashSet();
        var organizationTypeIds = snapshot.OrganizationTypes.Select(item => item.Id).ToHashSet();
        var purchasedModuleIds = snapshot.PurchasedModules.Select(item => item.Id).ToHashSet();
        var storageTypeIds = snapshot.StorageTypes.Select(item => item.Id).ToHashSet();
        var storageIds = snapshot.Storages.Select(item => item.Id).ToHashSet();
        var itemIds = snapshot.Items.Select(item => item.Id).ToHashSet();
        var catalogueIds = snapshot.Catalogues.Select(item => item.Id).ToHashSet();
        var referenceTypeIds = snapshot.ReferenceTypes.Select(item => item.Id).ToHashSet();
        var itemQualityIds = snapshot.ItemQualities.Select(item => item.Id).ToHashSet();
        var petitionStatusIds = snapshot.PetitionStatuses.Select(item => item.Id).ToHashSet();
        var petitionIds = snapshot.Petitions.Select(item => item.Id).ToHashSet();

        foreach (var organization in snapshot.Organizations)
        {
            Ensure(!organization.OrganizationTypeId.HasValue || organizationTypeIds.Contains(organization.OrganizationTypeId.Value), $"Organization {organization.Name} references a missing organization type.");
            Ensure(!organization.CompanyId.HasValue || organizationIds.Contains(organization.CompanyId.Value), $"Organization {organization.Name} references a missing company.");
            Ensure(organization.CompanyId != organization.Id, $"Organization {organization.Name} cannot reference itself as company.");
        }

        foreach (var user in snapshot.Users)
        {
            Ensure(organizationIds.Contains(user.OrganizationId), $"User {user.UserName} references a missing organization.");
            Ensure(locationIds.Contains(user.LocationId), $"User {user.UserName} references a missing location.");
            Ensure(roleIds.Contains(user.UserRoleId), $"User {user.UserName} references a missing role.");
            Ensure(snapshot.Roles.First(item => item.Id == user.UserRoleId).OrganizationId == user.OrganizationId, $"User {user.UserName} uses a role from another organization.");
        }

        foreach (var permission in snapshot.RolePermissions)
        {
            Ensure(roleIds.Contains(permission.RoleId), "A role permission references a missing role.");
            Ensure(moduleIds.Contains(permission.ModuleId), "A role permission references a missing module.");
            Ensure(actionIds.Contains(permission.ActionId), "A role permission references a missing action.");
        }

        foreach (var purchasedModule in snapshot.PurchasedModules)
        {
            Ensure(organizationIds.Contains(purchasedModule.OrganizationId), "A purchased module references a missing organization.");
            Ensure(moduleIds.Contains(purchasedModule.ModuleId), "A purchased module references a missing module.");
        }

        foreach (var userModule in snapshot.UserModules)
        {
            Ensure(purchasedModuleIds.Contains(userModule.PurchasedModuleId), "A user module references a missing purchased module.");
            Ensure(userIds.Contains(userModule.UserId), "A user module references a missing user.");
            var purchasedModule = snapshot.PurchasedModules.First(item => item.Id == userModule.PurchasedModuleId);
            var user = snapshot.Users.First(item => item.Id == userModule.UserId);
            Ensure(purchasedModule.OrganizationId == user.OrganizationId, $"User module for {user.UserName} points to another organization.");
        }

        foreach (var storageType in snapshot.StorageTypes)
        {
            Ensure(!storageType.ParentId.HasValue || storageTypeIds.Contains(storageType.ParentId.Value), $"Storage type {storageType.Name} references a missing parent.");
            Ensure(storageType.ParentId != storageType.Id, $"Storage type {storageType.Name} cannot reference itself.");
        }

        foreach (var storage in snapshot.Storages)
        {
            Ensure(storageTypeIds.Contains(storage.StorageTypeId), $"Storage {storage.Name} references a missing storage type.");
            Ensure(!storage.ParentId.HasValue || storageIds.Contains(storage.ParentId.Value), $"Storage {storage.Name} references a missing parent.");
            Ensure(storage.ParentId != storage.Id, $"Storage {storage.Name} cannot reference itself.");
        }

        foreach (var catalogue in snapshot.Catalogues)
        {
            Ensure(itemIds.Contains(catalogue.ItemId), "A catalogue references a missing item.");
        }

        foreach (var reference in snapshot.References)
        {
            Ensure(catalogueIds.Contains(reference.CatalogueId), "A reference points to a missing catalogue.");
            Ensure(referenceTypeIds.Contains(reference.ReferenceTypeId), "A reference points to a missing reference type.");
        }

        foreach (var inventory in snapshot.Inventories)
        {
            Ensure(catalogueIds.Contains(inventory.CatalogueId), "An inventory entry references a missing catalogue.");
            Ensure(storageIds.Contains(inventory.StorageId), "An inventory entry references a missing storage.");
            Ensure(itemQualityIds.Contains(inventory.ItemQualityId), "An inventory entry references a missing item quality.");
            Ensure(inventory.Quantity >= 0, "An inventory entry cannot have a negative quantity.");
        }

        foreach (var petition in snapshot.Petitions)
        {
            Ensure(userIds.Contains(petition.PetitionaryUserId), "A petition references a missing user.");
            Ensure(organizationIds.Contains(petition.PetitionaryOrganizationId), "A petition references a missing petitionary organization.");
            Ensure(organizationIds.Contains(petition.ReceiverOrganizationId), "A petition references a missing receiver organization.");
            Ensure(petitionStatusIds.Contains(petition.StatusId), "A petition references a missing status.");
            Ensure(snapshot.Users.First(item => item.Id == petition.PetitionaryUserId).OrganizationId == petition.PetitionaryOrganizationId, "A petition user belongs to another organization.");
        }

        foreach (var detail in snapshot.PetitionDetails)
        {
            Ensure(petitionIds.Contains(detail.PetitionId), "A petition detail references a missing petition.");
            Ensure(itemIds.Contains(detail.ItemId), "A petition detail references a missing item.");
            Ensure(detail.Quantity > 0, "A petition detail must have positive quantity.");
            Ensure(detail.Amount >= 0, "A petition detail cannot have negative amount.");
        }

        foreach (var audit in snapshot.Audits)
        {
            Ensure(moduleIds.Contains(audit.ModuleId), "An audit entry references a missing module.");
            Ensure(actionIds.Contains(audit.ActionId), "An audit entry references a missing action.");
            Ensure(userIds.Contains(audit.UserId), "An audit entry references a missing user.");
        }
    }

    private static void EnsureUnique(IEnumerable<Guid> ids, string label)
    {
        var list = ids.ToList();
        if (list.Count != list.Distinct().Count())
        {
            throw new InvalidOperationException($"Workshop mock seed contains duplicate ids in {label}.");
        }
    }

    private static void Ensure(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
