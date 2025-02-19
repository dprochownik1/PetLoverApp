using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<ProductDto> Products);

public class GetProductsByCategoryQueryValidator : AbstractValidator<CreateProductCommand>
{
    public GetProductsByCategoryQueryValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .Must(category => Enum.TryParse<Category>(category, out _)).WithMessage("Invalid category");
    }
}

internal class GetProductsByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(product => product.Category == query.Category)
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResult(products.Adapt<IEnumerable<ProductDto>>());
    }
}