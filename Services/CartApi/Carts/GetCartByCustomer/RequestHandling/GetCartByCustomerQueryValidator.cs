namespace CartApi.Carts.GetCartByCustomer.RequestHandling;

public class GetCartByCustomerQueryValidator : AbstractValidator<GetCartByCustomerQuery>
{
    public GetCartByCustomerQueryValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required");
    }
}