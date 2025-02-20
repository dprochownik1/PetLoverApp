using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Carts.StoreCart.Data.Repository;

public class StoreCartCachedRepository(IStoreCartRepository repository, IDistributedCache cache) : IStoreCartRepository
{
    public async Task<Guid> StoreCart(CartDto cartDto, CancellationToken cancellationToken)
    {
        await repository.StoreCart(cartDto, cancellationToken);

        await cache.SetStringAsync(cartDto.CustomerId.ToString(), JsonSerializer.Serialize(cartDto), cancellationToken);

        return cartDto.CustomerId;
    }
}