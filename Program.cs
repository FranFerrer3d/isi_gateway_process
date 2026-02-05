using IsiGatewayProcess;
using IsiGatewayProcess.Middlewares;
using IsiGatewayProcess.Options;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services;
using IsiGatewayProcess.Services.Security;

using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Controllers + OpenAPI explorer
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "IsiGatewayProcess", Version = "v1" });
    options.CustomSchemaIds(t => t.FullName);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce: Bearer {token}"
    });


    // Requirement usando el tipo correcto: OpenApiSecuritySchemeReference
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });


});


// Options + DI
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<OrganizationSystemOptions>(builder.Configuration.GetSection("OrganizationSystem"));
builder.Services.AddSingleton<IJwtValidator, JwtValidator>();
builder.Services.AddHttpClient<IsiGatewayProcess.Repositories.OrganizationSystem.OrganizationSystemApiClient>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<OrganizationSystemOptions>>().Value;
    if (!string.IsNullOrWhiteSpace(options.BaseUrl))
    {
        client.BaseAddress = new Uri(options.BaseUrl);
    }
});

builder.Services.AddIsiGatewayProcess();

var app = builder.Build();

// Errores detallados en Development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Swagger en Development o Pre
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Pre"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IsiGatewayProcess v1");
    });
}

app.UseHttpsRedirection();

// Middleware JWT (si quieres excluir swagger dentro del middleware, filtra por path allí)
app.UseMiddleware<JwtAuthMiddleware>();

// Map Controllers
app.MapControllers();

//// Seed solo en Development
//if (app.Environment.IsDevelopment())
//{
//    using var scope = app.Services.CreateScope();

//    var organizationRepository = scope.ServiceProvider.GetRequiredService<IOrganizationRepository>();
//    var locationRepository = scope.ServiceProvider.GetRequiredService<ILocationRepository>();
//    var roleRepository = scope.ServiceProvider.GetRequiredService<IRoleRepository>();
//    var moduleRepository = scope.ServiceProvider.GetRequiredService<IModuleRepository>();
//    var actionRepository = scope.ServiceProvider.GetRequiredService<IActionRepository>();
//    var rolePermissionRepository = scope.ServiceProvider.GetRequiredService<IRolePermissionRepository>();
//    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
//    var credentialRepository = scope.ServiceProvider.GetRequiredService<IUserCredentialRepository>();
//    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

//}

await app.RunAsync();
