namespace Catalog.API.Products.GetProducts.RequestHandling;

public record GetProductsResult(IEnumerable<ProductDto> Products);