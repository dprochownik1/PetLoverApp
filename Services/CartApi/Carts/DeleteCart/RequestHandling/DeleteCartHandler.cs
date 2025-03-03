namespace CartApi.Carts.DeleteCart.RequestHandling;

public class DeleteCartHandler(IDeleteCartRepository repository) : ICommandHandler<DeleteCartCommand, DeleteCartResult>
{
    public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteCartAsync(command.CustomerId, cancellationToken);

        return new DeleteCartResult(true);
    }
}
