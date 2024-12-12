using Microsoft.EntityFrameworkCore;
using Serilog;
using PF.Application;
using PF.Application.Activity.Mapping;
using PF.Infrastructure;
using PF.Persistence;
using PF.Persistence.Contexts;
using PF.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddSwaggerServices()
    .AddLocalizationServices()
    .AddCorsServices()
    .AddJsonSerializerServices()
    .AddRateLimiterServices()
    .AddOpenTelemetryServices();
builder.Services
    .AddPersistenceServices(builder.Configuration)
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddSerilogServices(builder.Configuration);

builder.Services.AddDbContext<PfDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));


builder.Host.UseSerilog();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerMiddleware();
}
app.UseLocalizationServices();
app.UseInfrastructureServices();
app.UseCorsServices();
app.UseRateLimiter();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
