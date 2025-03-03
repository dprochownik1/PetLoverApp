namespace CartApi.Data.Abstractions;

public interface IGetCartRepository
{
    Task<CartDto> GetCartAsync(Guid customerId, CancellationToken cancellationToken);
}