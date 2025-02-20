namespace CartApi.Carts.StoreCart.RequestHandling;

public class StoreCartCommandValidator : AbstractValidator<StoreCartCommand>
{
    public StoreCartCommandValidator()
    {
        RuleFor(x => x.CartDto).NotNull().WithMessage("CartDto can not be null");
        RuleFor(x => x.CartDto.CustomerId).NotEmpty().WithMessage("CustomerId is required");
    }
}