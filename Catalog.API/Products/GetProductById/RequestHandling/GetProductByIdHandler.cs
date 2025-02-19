namespace Catalog.API.Products.GetProductById.RequestHandling;

internal class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(product => product.Id == query.Id)
            .ToListAsync(cancellationToken);

        return new GetProductByIdResult(products.Adapt<ProductDto>());
    }
}