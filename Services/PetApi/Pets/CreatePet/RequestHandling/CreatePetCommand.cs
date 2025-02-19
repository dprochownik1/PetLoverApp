namespace PetApi.Pets.CreatePet.RequestHandling;

public record CreatePetCommand(
    Guid CustomerId,
    string Species,
    string Race,
    string Name,
    DateTime DateOfBirth,
    string ImageUrl) : ICommand<CreatePetResult>;