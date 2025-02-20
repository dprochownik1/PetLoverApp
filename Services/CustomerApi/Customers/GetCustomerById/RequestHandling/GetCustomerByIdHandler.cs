namespace CustomerApi.Customers.GetCustomerById.RequestHandling;

internal class GetCustomerByIdHandler(IDocumentSession session) : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
{
    public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var customer = await session.LoadAsync<Customer>(query.CustomerId, cancellationToken);

        return customer is null
            ? throw new CustomerNotFoundException(query.CustomerId)
            : new GetCustomerByIdResult(customer.Adapt<PetDto>());
    }
}