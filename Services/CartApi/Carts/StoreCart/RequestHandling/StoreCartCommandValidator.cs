namespace CartApi.Carts.StoreCart.RequestHandling;

public class StoreCartCommandValidator : AbstractValidator<StoreCartCommand>
{
    public StoreCartCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.CustomerId).NotEmpty().WithMessage("CustomerId is required");
    }
}