namespace ProductApi.Products.GetProducts.RequestHandling;

public record GetProductsResult(IEnumerable<ProductDto> Products);