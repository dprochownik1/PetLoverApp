namespace CustomerApi.Customers.DeleteCustomer.RequestHandling;

internal class DeleteCustomerHandler(IDocumentSession session) : ICommandHandler<DeleteCustomerCommand, DeleteCustomerResult>
{
    public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Customer>(command.CustomerId);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteCustomerResult(true);
    }
}