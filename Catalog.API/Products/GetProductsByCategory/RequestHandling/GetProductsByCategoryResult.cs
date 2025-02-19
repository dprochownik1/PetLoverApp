namespace ProductApi.Products.GetProductsByCategory.RequestHandling;

public record GetProductsByCategoryResult(IEnumerable<ProductDto> Products);