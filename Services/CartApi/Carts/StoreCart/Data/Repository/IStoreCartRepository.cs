namespace CartApi.Carts.StoreCart.Data.Repository;

public interface IStoreCartRepository
{
    Task<Guid> StoreCart(CartDto cartDto, CancellationToken cancellationToken);
}