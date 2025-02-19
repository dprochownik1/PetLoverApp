namespace Catalog.API.Products.GetProductsByCategory.RequestHandling;

public record GetProductsByCategoryResult(IEnumerable<ProductDto> Products);