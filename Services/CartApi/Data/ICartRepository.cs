namespace CartApi.Data;

public interface ICartRepository
{
    Task<Cart> GetCart(Guid customerId, CancellationToken cancellationToken = default);
    Task<Cart> StoreCart(Cart cart, CancellationToken cancellationToken = default);
    Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken = default);
}
