namespace CartApi.Exceptions;

public class CartNotFoundException : NotFoundException
{
    public CartNotFoundException(Guid customerId) : base("Cart", customerId)
    {
    }
}
