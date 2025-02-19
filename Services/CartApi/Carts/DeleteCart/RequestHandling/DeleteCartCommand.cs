namespace CartApi.Carts.DeleteCart.RequestHandling;

public record DeleteCartCommand(Guid CustomerId) : ICommand<DeleteCartResult>;