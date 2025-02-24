using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Extensions;

namespace Reservation.Application;

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