using CustomerApi.Customers.DeleteCustomer.Data.Clients;
using Microsoft.Extensions.Options;

namespace CustomerApi.Customers.DeleteCustomer.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDeletePetsByCustomerApiClient(this IServiceCollection serviceCollection)
    {
        var provider = serviceCollection.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IOptionsMonitor<ServiceUrlConfiguration>>();

        serviceCollection.AddHttpClient("DeletePetsByCustomerApiClient", client =>
            client.BaseAddress = new Uri(configuration.CurrentValue.PetApi));

        serviceCollection.AddScoped<IDeletePetsByCustomerApiClient, DeletePetsByCustomerApiClient>();

        return serviceCollection;
    }
}