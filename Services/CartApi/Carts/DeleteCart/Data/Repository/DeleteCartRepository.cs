namespace CartApi.Carts.DeleteCart.Data.Repository;

public class DeleteCartRepository(IDocumentSession session) : IDeleteCartRepository
{
    public async Task<bool> DeleteCart(Guid customerId, CancellationToken cancellationToken)
    {
        session.Delete<Cart>(customerId);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
}