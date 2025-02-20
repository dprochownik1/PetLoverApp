namespace CustomerApi.Customers.GetCustomerById.Data.Clients;

public interface IGetPetsByCustomerApiClient
{
    Task<IEnumerable<PetDto>> GetPetsByCustomerAsync(Guid customerId);
}