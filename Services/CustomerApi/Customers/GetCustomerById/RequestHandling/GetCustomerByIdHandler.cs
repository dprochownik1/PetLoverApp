using CustomerApi.Customers.GetCustomerById.Data.Clients;

namespace CustomerApi.Customers.GetCustomerById.RequestHandling;

internal class GetCustomerByIdHandler(IDocumentSession session, IGetPetsByCustomerApiClient petApiClient)
    : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
{
    public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var customer = await session.LoadAsync<Customer>(query.CustomerId, cancellationToken);

        if (customer is null) throw new CustomerNotFoundException(query.CustomerId);

        var pets = await petApiClient.GetPetsByCustomerAsync(query.CustomerId);

        return new GetCustomerByIdResult(new CustomerProfileDto(customer.Adapt<CustomerDto>(), pets));
    }
}