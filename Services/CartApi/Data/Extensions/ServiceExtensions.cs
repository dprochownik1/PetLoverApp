using CartApi.Configuration;
using MassTransit;
using Microsoft.Extensions.Options;

namespace CartApi.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCartRepository(this IServiceCollection services)
    {
        services.AddScoped<ICartRepository, CartRepository>();
        services.Decorate<ICartRepository, CartCachedRepository>();
        services.AddScoped<IGetCartRepository, CartRepository>();
        services.Decorate<IGetCartRepository, CartCachedRepository>();
        services.AddScoped<IStoreCartRepository, CartRepository>();
        services.Decorate<IStoreCartRepository, CartCachedRepository>();
        services.AddScoped<IDeleteCartRepository, CartRepository>();
        services.Decorate<IDeleteCartRepository, CartCachedRepository>();

        return services;
    }

    public static IServiceCollection AddMessageBroker(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IOptions<MessageBrokerConfiguration>>();

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration.Value.Host), host =>
                {
                    host.Username(configuration.Value.Username);
                    host.Password(configuration.Value.Password);
                });
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MessageBrokerConfiguration>(configuration.GetSection(nameof(MessageBrokerConfiguration)));

        MappingConfiguration.RegisterMaps();

        return services;
    }
}