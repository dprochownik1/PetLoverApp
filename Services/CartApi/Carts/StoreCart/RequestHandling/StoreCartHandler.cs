using CartApi.Carts.StoreCart.Data.Repository;

namespace CartApi.Carts.StoreCart.RequestHandling;

public class StoreCartHandler(IStoreCartRepository repository) : ICommandHandler<StoreCartCommand, StoreCartResult>
{
    public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
    {
        var result = await repository.StoreCart(command.CartDto, cancellationToken);

        return new StoreCartResult(result);
    }
}
