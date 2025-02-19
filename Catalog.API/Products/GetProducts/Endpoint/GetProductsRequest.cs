namespace Catalog.API.Products.GetProducts.Endpoint;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 15);