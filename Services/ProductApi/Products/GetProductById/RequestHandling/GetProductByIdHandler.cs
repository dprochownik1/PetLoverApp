namespace ProductApi.Products.GetProductById.RequestHandling;

internal class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var products = await session.LoadAsync<Product>(query.Id, cancellationToken);

        return new GetProductByIdResult(products.Adapt<ProductDto>());
    }
}