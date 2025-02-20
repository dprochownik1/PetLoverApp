namespace CustomerApi.Customers.DeleteCustomer.Data.Clients;

public class DeletePetsByCustomerApiClient(IHttpClientFactory clientFactory) : IDeletePetsByCustomerApiClient
{
    private const string Endpoint = "pets/customer";

    public async Task DeletePetsByCustomerAsync(Guid customerId)
    {
        using var client = clientFactory.CreateClient("GetPetsByCustomerApiClient");
        var uri = new Uri(client.BaseAddress!, $"{Endpoint}/{customerId}");

        var response = await client.DeleteAsync(uri);
        response.EnsureSuccessStatusCode();
    }
}