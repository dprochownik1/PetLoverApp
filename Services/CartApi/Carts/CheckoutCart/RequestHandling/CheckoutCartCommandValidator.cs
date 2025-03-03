namespace CartApi.Carts.CheckoutCart.RequestHandling;

public class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand>
{
    public CheckoutCartCommandValidator()
    {
        RuleFor(x => x.CartCheckout).NotNull().WithMessage("Cart checkout cannot be null");
    }
}
