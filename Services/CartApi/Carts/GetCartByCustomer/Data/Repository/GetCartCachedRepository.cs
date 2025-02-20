using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Carts.GetCartByCustomer.Data.Repository;

public class GetCartCachedRepository(IGetCartRepository repository, IDistributedCache cache) : IGetCartRepository
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
}