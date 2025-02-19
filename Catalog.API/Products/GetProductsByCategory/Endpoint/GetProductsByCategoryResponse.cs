namespace ProductApi.Products.GetProductsByCategory.Endpoint;

public record GetProductsByCategoryResponse(IEnumerable<ProductDto> Products);