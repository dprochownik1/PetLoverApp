namespace ProductApi.Products.GetProducts.Endpoint;

public record GetProductsResponse(IEnumerable<ProductDto> Products);