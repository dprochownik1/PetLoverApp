namespace ProductApi.Products.GetProductsByCategory.RequestHandling;

public record GetProductsByCategoryQuery(string Category, int? PageNumber = 1, int? PageSize = 15) : IQuery<GetProductsByCategoryResult>;