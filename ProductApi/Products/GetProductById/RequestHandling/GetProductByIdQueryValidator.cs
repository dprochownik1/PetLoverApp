namespace ProductApi.Products.GetProductById.RequestHandling;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
    }
}