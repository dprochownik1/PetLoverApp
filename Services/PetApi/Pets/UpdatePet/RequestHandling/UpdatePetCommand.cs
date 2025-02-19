namespace PetApi.Pets.UpdatePet.RequestHandling;

public record UpdatePetCommand(
    Guid Id,
    string Species,
    string Race,
    string Name,
    DateTime DateOfBirth,
    string ImageUrl) : ICommand<UpdatePetResult>;