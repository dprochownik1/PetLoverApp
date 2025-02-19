namespace PetApi.Pets.GetPetById.RequestHandling;

public record GetPetByIdQuery(Guid Id) : IQuery<GetPetByIdResult>;