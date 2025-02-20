namespace CartApi.Carts.GetCartByCustomer.Data.Repository;

public interface IGetCartRepository
{
    Task<CartDto> GetCart(Guid customerId, CancellationToken cancellationToken);
}