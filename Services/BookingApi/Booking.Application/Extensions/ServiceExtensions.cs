using System.Reflection;
using Booking.Application.Configuration;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Booking.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var messageBrokerConfig = provider.GetRequiredService<IOptions<MessageBrokerConfiguration>>();

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumers(Assembly.GetExecutingAssembly());

            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(messageBrokerConfig.Value.Host), host =>
                {
                    host.Username(messageBrokerConfig.Value.Username);
                    host.Password(messageBrokerConfig.Value.Password);
                });
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MessageBrokerConfiguration>(configuration.GetSection(nameof(MessageBrokerConfiguration)));

        return services;
    }
}