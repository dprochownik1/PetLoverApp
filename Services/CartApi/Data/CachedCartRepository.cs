using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Data;

public class CachedCartRepository(ICartRepository repository, IDistributedCache cache) : ICartRepository
{
    public async Task<Cart> GetCart(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cachedCart = await cache.GetStringAsync(customerId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedCart))
            return JsonSerializer.Deserialize<Cart>(cachedCart)!;

        var cart = await repository.GetCart(customerId, cancellationToken);
        await cache.SetStringAsync(customerId.ToString(), JsonSerializer.Serialize(cart), cancellationToken);
        return cart;
    }

    public async Task<Cart> StoreCart(Cart cart, CancellationToken cancellationToken = default)
    {
        await repository.StoreCart(cart, cancellationToken);

        await cache.SetStringAsync(cart.CustomerId.ToString(), JsonSerializer.Serialize(cart), cancellationToken);

        return cart;
    }

    public async Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken = default)
    {
        await repository.DeleteCart(customerId, cancellationToken);

        await cache.RemoveAsync(customerId.ToString(), cancellationToken);

        return true;
    }
}
