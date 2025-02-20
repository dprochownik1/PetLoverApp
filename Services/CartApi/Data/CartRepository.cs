namespace CartApi.Data;

public class CartRepository(IDocumentSession session) : ICartRepository
{
    public async Task<CartDto> GetCart(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cart = await session.LoadAsync<Cart>(customerId, cancellationToken);
        if (cart is null) throw new CartNotFoundException(customerId);

        return cart.Adapt<CartDto>();
    }

    public async Task<Guid> StoreCart(CartDto cart, CancellationToken cancellationToken = default)
    {
        session.Store(cart);
        await session.SaveChangesAsync(cancellationToken);
        return cart.CustomerId;
    }

    public async Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken = default)
    {
        session.Delete<Cart>(customerId);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
}
