namespace PetApi.Pets.DeletePet.RequestHandling;

internal class DeletePetHandler(IDocumentSession session) : ICommandHandler<DeletePetCommand, DeletePetResult>
{
    public async Task<DeletePetResult> Handle(DeletePetCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Pet>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeletePetResult(true);
    }
}