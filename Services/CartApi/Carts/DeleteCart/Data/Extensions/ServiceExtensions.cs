using CartApi.Carts.DeleteCart.Data.Repository;

namespace CartApi.Carts.DeleteCart.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDeleteCartFeature(this IServiceCollection services)
    {
        services.AddScoped<IDeleteCartRepository, DeleteCartRepository>();
        services.Decorate<IDeleteCartRepository, DeleteCartCachedRepository>();
        return services;
    }
}