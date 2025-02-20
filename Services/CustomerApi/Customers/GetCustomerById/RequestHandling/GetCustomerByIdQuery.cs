namespace CustomerApi.Customers.GetCustomerById.RequestHandling;

public record GetCustomerByIdQuery(Guid CustomerId) : IQuery<GetCustomerByIdResult>;