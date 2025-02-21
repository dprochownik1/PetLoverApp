using Microsoft.Extensions.DependencyInjection;

namespace Reservation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;   
    }
}