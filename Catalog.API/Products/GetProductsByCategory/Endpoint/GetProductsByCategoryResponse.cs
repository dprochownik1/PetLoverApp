namespace Catalog.API.Products.GetProductsByCategory.Endpoint;

public record GetProductsByCategoryResponse(IEnumerable<ProductDto> Products);