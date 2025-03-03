namespace CartApi.Data.Repository;

public class CartRepository(IDocumentSession session) : ICartRepository
{
    public async Task<CartDto> GetCartAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var cart = await session.LoadAsync<Cart>(customerId, cancellationToken);
        return cart is null
            ? throw new CartNotFoundException(customerId)
            : cart.Adapt<CartDto>();
    }

    public async Task<bool> DeleteCartAsync(Guid customerId, CancellationToken cancellationToken)
    {
        session.Delete<Cart>(customerId);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Guid> StoreCartAsync(CartDto cartDto, CancellationToken cancellationToken)
    {
        var cart = cartDto.Adapt<Cart>();
        session.Store(cartDto);
        await session.SaveChangesAsync(cancellationToken);
        return cartDto.CustomerId;
    }
}