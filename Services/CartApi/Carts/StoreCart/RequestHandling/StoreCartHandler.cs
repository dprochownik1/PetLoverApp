namespace CartApi.Carts.StoreCart.RequestHandling;

public class StoreCartHandler(IStoreCartRepository repository) : ICommandHandler<StoreCartCommand, StoreCartResult>
{
    public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
    {
        var result = await repository.StoreCartAsync(command.CartDto, cancellationToken);

        return new StoreCartResult(result);
    }
}
