namespace PetApi.Pets.CreatePet.Endpoint;

public record CreatePetRequest(
    Guid CustomerId,
    string Species,
    string Race,
    string Name,
    DateTime DateOfBirth,
    string ImageUrl);