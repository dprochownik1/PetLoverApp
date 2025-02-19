namespace Catalog.API.Products.GetProductsByCategory.RequestHandling;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;