namespace PetApi.Pets.UpdatePet.RequestHandling;

internal class UpdatePetHandler(IDocumentSession session)
    : ICommandHandler<UpdatePetCommand, UpdatePetResult>
{
    public async Task<UpdatePetResult> Handle(UpdatePetCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Pet>(command.Id, cancellationToken);

        if (product is null)
        {
            throw new PetNotFoundException(command.Id);
        }

        product.Name = command.Name;
        product.Species = command.Species;
        product.Race = command.Race;
        product.DateOfBirth = command.DateOfBirth;
        product.ImageUrl = command.ImageUrl;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdatePetResult(true);
    }
}