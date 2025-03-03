using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Data.Repository;

public class CartCachedRepository(ICartRepository repository, IDistributedCache cache) : ICartRepository
{
    public async Task<CartDto> GetCartAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var cachedCart = await cache.GetStringAsync(customerId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedCart))
            return JsonSerializer.Deserialize<CartDto>(cachedCart)!;

        var cart = await repository.GetCartAsync(customerId, cancellationToken);
        await cache.SetStringAsync(customerId.ToString(), JsonSerializer.Serialize(cart), cancellationToken);
        return cart;
    }

    public async Task<bool> DeleteCartAsync(Guid customerId, CancellationToken cancellationToken)
    {
        await repository.DeleteCartAsync(customerId, cancellationToken);

        await cache.RemoveAsync(customerId.ToString(), cancellationToken);

        return true;
    }

    public async Task<Guid> StoreCartAsync(CartDto cartDto, CancellationToken cancellationToken)
    {
        await repository.StoreCartAsync(cartDto, cancellationToken);

        await cache.SetStringAsync(cartDto.CustomerId.ToString(), JsonSerializer.Serialize(cartDto), cancellationToken);

        return cartDto.CustomerId;
    }
}