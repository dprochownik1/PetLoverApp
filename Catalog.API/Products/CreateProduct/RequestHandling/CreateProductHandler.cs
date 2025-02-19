namespace ProductApi.Products.CreateProduct.RequestHandling;

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