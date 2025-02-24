using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Data;
using Reservation.Infrastructure.Data.Interceptors;

namespace Reservation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        serviceCollection.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        serviceCollection.AddScoped<ISaveChangesInterceptor, AuditingInterceptor>();
        serviceCollection.AddScoped<ISaveChangesInterceptor, DomainEventsPublishingInterceptor>();

        serviceCollection.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });

        
        return serviceCollection;
    }
}