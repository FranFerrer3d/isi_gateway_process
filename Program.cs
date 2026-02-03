using IsiGatewayProcess;
using IsiGatewayProcess.Middlewares;
using IsiGatewayProcess.Options;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services;
using IsiGatewayProcess.Services.Security;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ Swagger services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IsiGatewayProcess",
        Version = "v1",
    });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresá el token JWT con el prefijo 'Bearer '.",
    };

    options.AddSecurityDefinition("Bearer", jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurityScheme,
            Array.Empty<string>()
        },
    });
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton<IJwtValidator, JwtValidator>();

builder.Services.AddIsiGatewayProcess();

var app = builder.Build();
 
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Pre"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IsiGatewayProcess v1");
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<JwtAuthMiddleware>();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var organizationRepository = scope.ServiceProvider.GetRequiredService<IOrganizationRepository>();
    var locationRepository = scope.ServiceProvider.GetRequiredService<ILocationRepository>();
    var roleRepository = scope.ServiceProvider.GetRequiredService<IRoleRepository>();
    var moduleRepository = scope.ServiceProvider.GetRequiredService<IModuleRepository>();
    var actionRepository = scope.ServiceProvider.GetRequiredService<IActionRepository>();
    var rolePermissionRepository = scope.ServiceProvider.GetRequiredService<IRolePermissionRepository>();
    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    var credentialRepository = scope.ServiceProvider.GetRequiredService<IUserCredentialRepository>();
    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

    var existingOrganizations = await organizationRepository.CountAsync();
    if (existingOrganizations == 0)
    {
        var organization = new IsiGatewayProcess.DTOs.Organizations.OrganizationDto
        {
            Id = Guid.NewGuid(),
            Name = "Default Organization",
            Description = "Seed organization",
            RegistrationDate = DateTimeOffset.UtcNow,
            DeregistrationDate = null,
        };
        await organizationRepository.AddAsync(organization);

        var location = new IsiGatewayProcess.DTOs.Locations.LocationDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = organization.Id,
            Name = "Main Location",
            Description = "Seed location",
            RegistrationDate = DateTimeOffset.UtcNow,
            DeregistrationDate = null,
        };
        await locationRepository.AddAsync(location);

        var role = new IsiGatewayProcess.DTOs.Roles.RoleDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = organization.Id,
            Code = "ADMIN",
            Description = "Administrator",
        };
        await roleRepository.AddAsync(role);

        var module = new IsiGatewayProcess.DTOs.Modules.ModuleDto
        {
            Id = Guid.NewGuid(),
            Code = "GATEWAY",
            Name = "Gateway",
            Description = "Gateway module",
        };
        await moduleRepository.AddAsync(module);

        var action = new IsiGatewayProcess.DTOs.Actions.ActionDto
        {
            Id = Guid.NewGuid(),
            Code = "FULL_ACCESS",
            Name = "Full access",
            Description = "Seed action",
        };
        await actionRepository.AddAsync(action);

        await rolePermissionRepository.AddAsync(new IsiGatewayProcess.DTOs.RolePermissions.RolePermissionDto
        {
            Id = Guid.NewGuid(),
            RoleId = role.Id,
            ModuleId = module.Id,
            ActionId = action.Id,
        });

        var adminUser = new IsiGatewayProcess.DTOs.Users.UserDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = organization.Id,
            LocationId = location.Id,
            UserRoleId = role.Id,
            UserName = "admin",
            Name = "Admin",
            LastName = "User",
            Email = "admin@local.test",
            RegistrationDate = DateTimeOffset.UtcNow,
            DeregistrationDate = null,
        };
        var created = await userRepository.AddAsync(adminUser);
        await credentialRepository.SetPasswordHashAsync(created.Id, passwordHasher.Hash("Admin123!"));
    }
}

app.MapControllers();

app.Run();
