namespace Catalog.API.Products.DeleteProduct.RequestHandling;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;