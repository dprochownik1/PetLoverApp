namespace ProductApi.Products.GetProductsByCategory.RequestHandling;

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