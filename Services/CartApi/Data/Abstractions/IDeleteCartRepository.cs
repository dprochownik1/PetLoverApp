namespace CartApi.Data.Abstractions;

public interface IDeleteCartRepository
{
    Task<bool> DeleteCartAsync(Guid customerId, CancellationToken cancellationToken);
}