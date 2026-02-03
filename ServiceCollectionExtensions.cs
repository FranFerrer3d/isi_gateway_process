using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IsiGatewayProcess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIsiGatewayProcess(this IServiceCollection services)
    {
        services.AddScoped<ITimeRepository, TimeRepository>();
        services.AddScoped<IHealthService, HealthService>();
        services.AddScoped<IOrganizationTypeRepository, InMemoryOrganizationTypeRepository>();
        services.AddScoped<IOrganizationTypeService, OrganizationTypeService>();
        services.AddScoped<IOrganizationRepository, InMemoryOrganizationRepository>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IModuleRepository, InMemoryModuleRepository>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<IPurchasedModuleRepository, InMemoryPurchasedModuleRepository>();
        services.AddScoped<IPurchasedModuleService, PurchasedModuleService>();
        services.AddScoped<IActionRepository, InMemoryActionRepository>();
        services.AddScoped<IActionService, ActionService>();
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleRepository, InMemoryUserRoleRepository>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserModuleAccessRepository, InMemoryUserModuleAccessRepository>();
        services.AddScoped<IUserModuleAccessService, UserModuleAccessService>();
        services.AddScoped<IStorageRepository, InMemoryStorageRepository>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IAreaRepository, InMemoryAreaRepository>();
        services.AddScoped<IAreaService, AreaService>();
        services.AddScoped<IContainerRepository, InMemoryContainerRepository>();
        services.AddScoped<IContainerService, ContainerService>();
        services.AddScoped<IItemPhysicalStateRepository, InMemoryItemPhysicalStateRepository>();
        services.AddScoped<IItemPhysicalStateService, ItemPhysicalStateService>();
        services.AddScoped<IItemNatureRepository, InMemoryItemNatureRepository>();
        services.AddScoped<IItemNatureService, ItemNatureService>();
        services.AddScoped<IItemQualityRepository, InMemoryItemQualityRepository>();
        services.AddScoped<IItemQualityService, ItemQualityService>();
        services.AddScoped<IItemRepository, InMemoryItemRepository>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ICatalogueRepository, InMemoryCatalogueRepository>();
        services.AddScoped<ICatalogueService, CatalogueService>();
        services.AddScoped<IInventoryRepository, InMemoryInventoryRepository>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IPetitionStatusRepository, InMemoryPetitionStatusRepository>();
        services.AddScoped<IPetitionStatusService, PetitionStatusService>();
        services.AddScoped<IPetitionRepository, InMemoryPetitionRepository>();
        services.AddScoped<IPetitionService, PetitionService>();
        services.AddScoped<IPetitionDetailRepository, InMemoryPetitionDetailRepository>();
        services.AddScoped<IPetitionDetailService, PetitionDetailService>();
        services.AddScoped<IAuditRepository, InMemoryAuditRepository>();
        services.AddScoped<IAuditService, AuditService>();
        return services;
    }
}
