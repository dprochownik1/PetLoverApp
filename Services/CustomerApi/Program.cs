using CustomerApi.Customers.DeleteCustomer.Data.Extensions;
using CustomerApi.Customers.GetCustomerById.Data.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

//Add services to the DI container.
var assembly = typeof(Program).Assembly;
var connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(FluentValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(connection);
}).UseLightweightSessions();

builder.Services.Configure<ServiceUrlConfiguration>(builder.Configuration.GetSection(nameof(ServiceUrlConfiguration)));
builder.Services
    .AddGetPetsByCustomerApiClient()
    .AddDeletePetsByCustomerApiClient();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddHealthChecks().AddNpgSql(connection);

var app = builder.Build();

//Configure HTTP request pipeline.

app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();