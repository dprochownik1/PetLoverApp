namespace PetApi.Pets.DeletePet.RequestHandling;

public record DeletePetCommand(Guid Id) : ICommand<DeletePetResult>;