namespace Catalog.API.Products.GetProductById.RequestHandling;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;