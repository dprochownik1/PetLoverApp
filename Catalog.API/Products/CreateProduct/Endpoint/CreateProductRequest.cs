namespace Catalog.API.Products.CreateProduct.Endpoint;

public record CreateProductRequest(string Name, string Description,
    string Category, string ImageFile, decimal Price, TimeSpan Duration);