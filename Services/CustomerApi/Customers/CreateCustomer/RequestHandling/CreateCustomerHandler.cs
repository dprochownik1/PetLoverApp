namespace CustomerApi.Customers.CreateCustomer.RequestHandling;

public class CreateCustomerHandler(IDocumentSession session) : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = command.Customer.Adapt<Customer>();
        session.Store(customer);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateCustomerResult(customer.Id);
    }
}