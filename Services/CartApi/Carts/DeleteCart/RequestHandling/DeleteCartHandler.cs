namespace CartApi.Carts.DeleteCart.RequestHandling;

public class DeleteCartHandler(ICartRepository repository) 
    : ICommandHandler<DeleteCartCommand, DeleteCartResult>
{
    public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteCart(command.CustomerId, cancellationToken);

        return new DeleteCartResult(true);
    }
}
