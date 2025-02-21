namespace ReservationApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static WebApplication UseApiServices(this WebApplication webApplication)
    {
        return webApplication;
    }
}