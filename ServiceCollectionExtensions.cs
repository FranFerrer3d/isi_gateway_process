using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IsiGatewayProcess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIsiGatewayProcess(this IServiceCollection services)
    {
        services.AddScoped<IHealthService, HealthService>();
        services.AddScoped<IOrganizationRepository, InMemoryOrganizationRepository>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<ILocationRepository, InMemoryLocationRepository>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IRoleRepository, InMemoryRoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IModuleRepository, InMemoryModuleRepository>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<IActionRepository, InMemoryActionRepository>();
        services.AddScoped<IActionService, ActionService>();
        services.AddScoped<IRolePermissionRepository, InMemoryRolePermissionRepository>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddScoped<IUserCredentialRepository, InMemoryUserCredentialRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRefreshTokenRepository, InMemoryRefreshTokenRepository>();
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
