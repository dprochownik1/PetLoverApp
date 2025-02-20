namespace CustomerApi.Exceptions;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(Guid customerId) : base("Customer", customerId)
    {
    }
}