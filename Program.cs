using System.Text;
using IsiGatewayProcess;
using IsiGatewayProcess.Options;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ Swagger services
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
        };
    });
builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    var credentialRepository = scope.ServiceProvider.GetRequiredService<IUserCredentialRepository>();
    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
    var existing = await userRepository.FindByUserNameOrEmailAsync("admin");
    if (existing is null)
    {
        var adminUser = new IsiGatewayProcess.DTOs.Users.UserDto
        {
            Id = Guid.NewGuid(),
            UserName = "admin",
            Name = "Admin",
            LastName = "User",
            Email = "admin@local.test",
            UserRoleId = Guid.NewGuid(),
            LocationId = Guid.NewGuid(),
            RegistrationDate = DateTimeOffset.UtcNow,
            DeregistrationDate = null,
        };
        var created = await userRepository.CreateAsync(adminUser);
        await credentialRepository.SetPasswordHashAsync(created.Id, passwordHasher.Hash("Admin123!"));
    }
}

app.MapControllers();

app.Run();
