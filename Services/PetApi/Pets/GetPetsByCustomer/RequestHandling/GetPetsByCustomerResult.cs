namespace PetApi.Pets.GetPetsByCustomer.RequestHandling;

public record GetPetsByCustomerResult(IEnumerable<PetDto> Pets);