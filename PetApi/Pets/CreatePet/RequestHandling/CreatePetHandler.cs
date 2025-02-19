namespace PetApi.Pets.CreatePet.RequestHandling;

internal class CreatePetHandler(IDocumentSession session) : ICommandHandler<CreatePetCommand, CreatePetResult>
{
    public async Task<CreatePetResult> Handle(CreatePetCommand createPetCommand, CancellationToken cancellationToken)
    {
        var pet = createPetCommand.Adapt<Pet>();

        session.Store(pet);
        await session.SaveChangesAsync(cancellationToken);

        return new CreatePetResult(pet.Id);
    }
}