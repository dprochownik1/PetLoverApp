namespace CustomerApi.Customers.GetCustomerById.Data.Clients;

public class GetPetsByCustomerApiClient(IHttpClientFactory clientFactory) : IGetPetsByCustomerApiClient
{
    private const string Endpoint = "pets/customer";

    public async Task<IEnumerable<PetDto>> GetPetsByCustomerAsync(Guid customerId)
    {
        using var client = clientFactory.CreateClient("GetPetsByCustomerApiClient");
        var uri = new Uri(client.BaseAddress!, $"{Endpoint}/{customerId}");

        var response = await client.GetFromJsonAsync<GetPetsByCustomerResponseDto>(uri)
                       ?? throw new InvalidOperationException($"Failed to fetch pets for customer {customerId}");

        return response.Pets;
    }
}