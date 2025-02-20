using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Carts.DeleteCart.Data.Repository
{
    public class DeleteCartCachedRepository(IDeleteCartRepository repository, IDistributedCache cache) : IDeleteCartRepository
    {
        public async Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken)
        {
            await repository.DeleteCart(customerId, cancellationToken);

            await cache.RemoveAsync(customerId.ToString(), cancellationToken);

            return true;
        }
    }
}
