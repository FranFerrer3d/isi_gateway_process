using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ Swagger services
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITimeRepository, TimeRepository>();
builder.Services.AddScoped<IHealthService, HealthService>();

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

app.MapControllers();

app.Run();
