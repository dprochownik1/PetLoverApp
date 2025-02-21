using Reservation.Application;
using Reservation.Infrastructure;
using ReservationApi;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

//Configure the HTTP request pipeline.


app.Run();
