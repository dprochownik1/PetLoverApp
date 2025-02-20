namespace CartApi.Data;

public interface ICartRepository
{
    Task<CartDto> GetCart(Guid customerId, CancellationToken cancellationToken);
    Task<Guid> StoreCart(CartDto cart, CancellationToken cancellationToken);
    Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken);
}
