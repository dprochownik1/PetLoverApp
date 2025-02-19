namespace Catalog.API.Products.GetProducts.RequestHandling;

internal class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 15, cancellationToken);

        return new GetProductsResult(products.Adapt<IEnumerable<ProductDto>>());
    }
}