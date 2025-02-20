namespace PetApi.Pets.DeletePetsByCustomer.RequestHandling;

internal class DeletePetsByCustomerHandler(IDocumentSession session) : ICommandHandler<DeletePetsByCustomerCommand, DeletePetsByCustomerResult>
{
    public async Task<DeletePetsByCustomerResult> Handle(DeletePetsByCustomerCommand byCustomerCommand, CancellationToken cancellationToken)
    {
        session.Delete<Pet>(byCustomerCommand.CustomerId);
        await session.SaveChangesAsync(cancellationToken);

        return new DeletePetsByCustomerResult(true);
    }
}