using MassTransit;

namespace CartApi.Carts.CheckoutCart.RequestHandling;

public class CheckoutCartHandler(ICartRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
{
    public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
    {
        var result = new CheckoutCartResult(true);

        var cart =  await repository.GetCartAsync(command.CartCheckout.CustomerId, cancellationToken);

        var cartItem = cart.Items.FirstOrDefault(ci => ci.Equals(command.CartCheckout.CartItem));

        if (cartItem is null) 
            throw new CartItemNotFoundException($"Cart item for product: {command.CartCheckout.CartItem.ProductId} has not been found");

        var cartCheckoutEvent = command.CartCheckout.Adapt<CartCheckoutEvent>();
        await publishEndpoint.Publish(cartCheckoutEvent, cancellationToken);

        //cart.Items.Remove(cartItem);

        //if (cart.Items.IsEmpty())
        //{
        //    await repository.DeleteCartAsync(command.CartCheckout.CustomerId, cancellationToken);

        //    return result;
        //}

        //await repository.StoreCartAsync(cart, cancellationToken);

        return result;
    }
}