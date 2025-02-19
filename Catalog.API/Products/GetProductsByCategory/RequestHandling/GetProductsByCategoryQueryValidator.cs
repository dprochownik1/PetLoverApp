namespace ProductApi.Products.GetProductsByCategory.RequestHandling;

public class GetProductsByCategoryQueryValidator : AbstractValidator<CreateProductCommand>
{
    public GetProductsByCategoryQueryValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .Must(category => Enum.TryParse<Category>(category, out _)).WithMessage("Invalid category");
    }
}