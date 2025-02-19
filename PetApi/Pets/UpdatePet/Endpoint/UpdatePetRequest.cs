namespace PetApi.Pets.UpdatePet.Endpoint;

public record UpdatePetRequest(
    Guid Id,
    string Species,
    string Race,
    string Name,
    DateTime DateOfBirth,
    string ImageFile);