namespace PetApi.Pets.GetPetsByCustomer.RequestHandling;

public record GetPetsByCustomerQuery(Guid CustomerId) : IQuery<GetPetsByCustomerResult>;