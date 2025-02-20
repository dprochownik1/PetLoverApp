namespace CustomerApi.Customers.UpdateCustomer.RequestHandling;

public class UpdateCustomerHandler(IDocumentSession session) : ICommandHandler<UpdateCustomerCommand, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await session.LoadAsync<Customer>(command.CustomerDto.Id, cancellationToken);

        if (customer is null) throw new CustomerNotFoundException(command.CustomerDto.Id);
        
        customer.Name = command.CustomerDto.Name;
        customer.LastName = command.CustomerDto.LastName;
        customer.EmailAddress = command.CustomerDto.EmailAddress;
        customer.PhoneNumber = command.CustomerDto.PhoneNumber;
        customer.Address = command.CustomerDto.Address.Adapt<Address>();

        session.Update(customer);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerResult(customer.Id);
    }
}