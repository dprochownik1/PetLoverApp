using System.Reflection;
using Booking.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace Booking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        MappingConfiguration.RegisterMaps();

        services.AddFeatureManagement();
        services.AddConfiguration(configuration);
        services.AddMessageBroker();

        return services;   
    }
}