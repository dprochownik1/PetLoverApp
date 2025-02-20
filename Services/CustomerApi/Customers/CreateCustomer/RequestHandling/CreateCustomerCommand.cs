namespace CustomerApi.Customers.CreateCustomer.RequestHandling;

public record CreateCustomerCommand(CreateCustomerDto Customer) : ICommand<CreateCustomerResult>;