using CartApi.Carts.StoreCart.Data.Repository;

namespace CartApi.Carts.StoreCart.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddStoreCartFeature(this IServiceCollection services)
    {
        services.AddScoped<IStoreCartRepository, StoreCartRepository>();
        services.Decorate<IStoreCartRepository, StoreCartCachedRepository>();
        return services;
    }
}