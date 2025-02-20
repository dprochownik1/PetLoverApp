namespace CustomerApi.Customers.UpdateCustomer.RequestHandling;

public record UpdateCustomerCommand(UpdateCustomerDto CustomerDto) : ICommand<UpdateCustomerResult>;