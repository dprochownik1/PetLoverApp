namespace CartApi.Exceptions;

public class CartItemNotFoundException : NotFoundException
{
    public CartItemNotFoundException(string message) : base(message)
    {
    }
}