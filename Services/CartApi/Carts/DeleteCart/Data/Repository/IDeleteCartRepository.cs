namespace CartApi.Carts.DeleteCart.Data.Repository;

public interface IDeleteCartRepository
{
    Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken);
}