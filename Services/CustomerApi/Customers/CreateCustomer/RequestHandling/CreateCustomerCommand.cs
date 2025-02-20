namespace CustomerApi.Customers.CreateCustomer.RequestHandling;

public record CreateCustomerCommand(CustomerDto CustomerDto) : ICommand<CreateCustomerResult>;