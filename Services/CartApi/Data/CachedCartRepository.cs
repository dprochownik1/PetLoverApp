using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Data;

public class CachedCartRepository(ICartRepository repository, IDistributedCache cache) : ICartRepository
{
    public async Task<CartDto> GetCart(Guid customerId, CancellationToken cancellationToken)
    {
        var cachedCart = await cache.GetStringAsync(customerId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedCart))
            return JsonSerializer.Deserialize<CartDto>(cachedCart)!;

        var cart = await repository.GetCart(customerId, cancellationToken);
        await cache.SetStringAsync(customerId.ToString(), JsonSerializer.Serialize(cart), cancellationToken);
        return cart;
    }

    public async Task<Guid> StoreCart(CartDto cart, CancellationToken cancellationToken)
    {
        await repository.StoreCart(cart, cancellationToken);

        await cache.SetStringAsync(cart.CustomerId.ToString(), JsonSerializer.Serialize(cart), cancellationToken);

        return cart.CustomerId;
    }

    public async Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken)
    {
        await repository.DeleteCart(customerId, cancellationToken);

        await cache.RemoveAsync(customerId.ToString(), cancellationToken);

        return true;
    }
}
