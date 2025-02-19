namespace Catalog.API.Products.UpdateProduct.RequestHandling;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("Product Id is required");
        RuleFor(command => command.Description)
            .MaximumLength(500).WithMessage("Description must not be longer than 500 characters");
        RuleFor(command => command.Category)
            .Must(category => Enum.TryParse<Category>(category, out _))
            .WithMessage("Invalid category");
        RuleFor(command => command.Name)
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}