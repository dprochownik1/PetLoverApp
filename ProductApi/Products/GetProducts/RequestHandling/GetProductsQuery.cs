namespace ProductApi.Products.GetProducts.RequestHandling;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 15) : IQuery<GetProductsResult>;