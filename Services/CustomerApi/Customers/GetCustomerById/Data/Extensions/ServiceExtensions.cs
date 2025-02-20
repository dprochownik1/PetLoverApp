using CustomerApi.Customers.GetCustomerById.Data.Clients;
using Microsoft.Extensions.Options;

namespace CustomerApi.Customers.GetCustomerById.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddGetPetsByCustomerApiClient(this IServiceCollection serviceCollection)
    {
        var provider = serviceCollection.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IOptionsMonitor<ServiceUrlConfiguration>>();

        serviceCollection.AddHttpClient("GetPetsByCustomerApiClient", client =>
            client.BaseAddress = new Uri(configuration.CurrentValue.PetApi));

        serviceCollection.AddScoped<IGetPetsByCustomerApiClient, GetPetsByCustomerApiClient>();
        
        return serviceCollection;
    }
}