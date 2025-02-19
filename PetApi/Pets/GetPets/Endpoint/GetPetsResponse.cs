namespace PetApi.Pets.GetPets.Endpoint;

public record GetPetsResponse(IEnumerable<PetDto> Pets);