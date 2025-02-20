namespace CartApi.Carts.StoreCart.RequestHandling;

public class StoreCartHandler(ICartRepository repository) : ICommandHandler<StoreCartCommand, StoreCartResult>
{
    public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
    {
        var result = await repository.StoreCart(command.CartDto, cancellationToken);

        return new StoreCartResult(result);
    }
}
