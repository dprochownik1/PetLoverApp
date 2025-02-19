namespace CartApi.Carts.StoreCart.RequestHandling;

public record StoreCartCommand(Cart Cart) : ICommand<StoreCartResult>;