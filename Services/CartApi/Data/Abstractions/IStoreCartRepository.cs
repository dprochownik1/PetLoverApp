namespace CartApi.Data.Abstractions;

public interface IStoreCartRepository
{
    Task<Guid> StoreCartAsync(CartDto cartDto, CancellationToken cancellationToken);
}