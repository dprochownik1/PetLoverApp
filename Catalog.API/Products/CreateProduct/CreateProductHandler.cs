namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    string Category,
    string ImageFile,
    decimal Price,
    TimeSpan Duration) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

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
        RuleFor( x => x.Description)
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

internal class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
    {
        var product = createProductCommand.Adapt<Product>();

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}