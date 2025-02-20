namespace CustomerApi.Customers.DeleteCustomer.RequestHandling;

public record DeleteCustomerCommand(Guid CustomerId) : ICommand<DeleteCustomerResult>;