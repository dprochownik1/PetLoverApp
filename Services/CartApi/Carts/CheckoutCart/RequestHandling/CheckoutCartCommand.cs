namespace CartApi.Carts.CheckoutCart.RequestHandling;

public record CheckoutCartCommand(CartCheckoutDto CartCheckout) : ICommand<CheckoutCartResult>;