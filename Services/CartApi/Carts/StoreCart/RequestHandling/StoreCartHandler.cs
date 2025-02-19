namespace CartApi.Carts.StoreCart.RequestHandling;

public class StoreCartHandler(ICartRepository repository) : ICommandHandler<StoreCartCommand, StoreCartResult>
{
    public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
    {
        await repository.StoreCart(command.Cart, cancellationToken);

        return new StoreCartResult(command.Cart.CustomerId);
    }
}
