using System.Reflection;
using Booking.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        MappingConfiguration.RegisterMaps();

        return serviceCollection;   
    }
}