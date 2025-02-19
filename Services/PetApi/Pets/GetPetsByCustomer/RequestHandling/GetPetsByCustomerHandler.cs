namespace PetApi.Pets.GetPetsByCustomer.RequestHandling;

internal class GetPetsByCustomerHandler(IDocumentSession session) : IQueryHandler<GetPetsByCustomerQuery, GetPetsByCustomerResult>
{
    public async Task<GetPetsByCustomerResult> Handle(GetPetsByCustomerQuery query, CancellationToken cancellationToken)
    {
        var pets = await session.Query<Pet>()
            .Where(pet => pet.CustomerId == query.CustomerId)
            .ToListAsync(cancellationToken);

        return new GetPetsByCustomerResult(pets.Adapt<IEnumerable<PetDto>>());
    }
}