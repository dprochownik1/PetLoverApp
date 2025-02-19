namespace PetApi.Pets.GetPets.RequestHandling;

public record GetPetsResult(IEnumerable<PetDto> Pets);