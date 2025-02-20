namespace CartApi.Carts.StoreCart.Data.Repository;

public class StoreCartRepository(IDocumentSession session) : IStoreCartRepository
{
    public async Task<Guid> StoreCart(CartDto cartDto, CancellationToken cancellationToken)
    {
        session.Store(cartDto);
        await session.SaveChangesAsync(cancellationToken);
        return cartDto.CustomerId;
    }
}