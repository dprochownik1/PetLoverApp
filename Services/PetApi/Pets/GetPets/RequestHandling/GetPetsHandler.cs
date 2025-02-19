namespace PetApi.Pets.GetPets.RequestHandling;

internal class GetPetsHandler(IDocumentSession session) : IQueryHandler<GetPetsQuery, GetPetsResult>
{
    public async Task<GetPetsResult> Handle(GetPetsQuery query, CancellationToken cancellationToken)
    {
        var pets = await session.Query<Pet>()
            .ToListAsync(cancellationToken);

        return new GetPetsResult(pets.Adapt<IEnumerable<PetDto>>());
    }
}