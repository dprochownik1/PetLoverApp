namespace PetApi.Pets.DeletePetsByCustomer.RequestHandling;

public record DeletePetsByCustomerCommand(Guid CustomerId) : ICommand<DeletePetsByCustomerResult>;