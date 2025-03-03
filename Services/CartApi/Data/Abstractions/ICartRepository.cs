namespace CartApi.Data.Abstractions;

public interface ICartRepository : IGetCartRepository, IDeleteCartRepository, IStoreCartRepository
{
}