namespace Catalog.API.Products.CreateProduct.RequestHandling;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(150).WithMessage("Name must not be longer than 150 characters");
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .Must(category => Enum.TryParse<Category>(category, out _)).WithMessage("Invalid category");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description must not be longer than 500 characters");
        RuleFor(x => x.ImageFile)
            .NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.Duration)
            .NotEmpty().WithMessage("Duration is required");
    }
}