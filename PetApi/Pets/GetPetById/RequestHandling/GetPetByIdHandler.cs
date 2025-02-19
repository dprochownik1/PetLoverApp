namespace PetApi.Pets.GetPetById.RequestHandling;

internal class GetPetByIdHandler(IDocumentSession session) : IQueryHandler<GetPetByIdQuery, GetPetByIdResult>
{
    public async Task<GetPetByIdResult> Handle(GetPetByIdQuery query, CancellationToken cancellationToken)
    {
        var pets = await session.Query<Pet>()
            .Where(pet => pet.Id == query.Id)
            .ToListAsync(cancellationToken);

        return new GetPetByIdResult(pets.Adapt<PetDto>());
    }
}