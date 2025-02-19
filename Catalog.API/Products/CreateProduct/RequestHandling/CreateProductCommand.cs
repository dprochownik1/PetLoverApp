namespace Catalog.API.Products.CreateProduct.RequestHandling;

public record CreateProductCommand(
    string Name,
    string Description,
    string Category,
    string ImageFile,
    decimal Price,
    TimeSpan Duration) : ICommand<CreateProductResult>;