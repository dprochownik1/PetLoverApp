namespace CartApi.Carts.StoreCart.RequestHandling;

public record StoreCartCommand(CartDto CartDto) : ICommand<StoreCartResult>;