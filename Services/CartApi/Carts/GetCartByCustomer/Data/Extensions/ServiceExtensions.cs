using CartApi.Carts.GetCartByCustomer.Data.Repository;

namespace CartApi.Carts.GetCartByCustomer.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddGetCartFeature(this IServiceCollection services)
    {
        services.AddScoped<IGetCartRepository, GetCartRepository>();
        services.Decorate<IGetCartRepository, GetCartCachedRepository>();
        return services;
    }
}