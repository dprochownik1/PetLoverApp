namespace Catalog.API.Products.UpdateProduct.Endpoint;

public record UpdateProductRequest(Guid Id, string Name, string Category,
    string Description, string ImageFile, decimal Price, TimeSpan Duration);