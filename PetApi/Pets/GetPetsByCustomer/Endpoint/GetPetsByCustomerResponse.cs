namespace PetApi.Pets.GetPetsByCustomer.Endpoint;

public record GetPetsByCustomerResponse(IEnumerable<PetDto> Pets);