using Booking.Application;
using Booking.Infrastructure;
using Booking.Infrastructure.Data.Extensions;
using BookingApi;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    await app.ApplyPendingMigrationsAsync();
}

app.UseApiServices();

app.Run();
