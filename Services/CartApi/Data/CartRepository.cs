namespace CartApi.Data;

public class CartRepository(IDocumentSession session) : ICartRepository
{
    public async Task<Cart> GetCart(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cart = await session.LoadAsync<Cart>(customerId, cancellationToken);
        
        return cart ?? throw new CartNotFoundException(customerId);
    }

    public async Task<Cart> StoreCart(Cart cart, CancellationToken cancellationToken = default)
    {
        session.Store(cart);
        await session.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken = default)
    {
        session.Delete<Cart>(customerId);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
}
