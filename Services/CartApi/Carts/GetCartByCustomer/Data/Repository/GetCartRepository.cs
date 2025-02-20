namespace CartApi.Carts.GetCartByCustomer.Data.Repository;

public class GetCartRepository(IDocumentSession session) : IGetCartRepository
{
    public async Task<CartDto> GetCart(Guid customerId, CancellationToken cancellationToken)
    {
        var cart = await session.LoadAsync<Cart>(customerId, cancellationToken);
        return cart is null
            ? throw new CartNotFoundException(customerId)
            : cart.Adapt<CartDto>();
    }
}