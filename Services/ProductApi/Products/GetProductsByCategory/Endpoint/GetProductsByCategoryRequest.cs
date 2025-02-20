namespace ProductApi.Products.GetProductsByCategory.Endpoint;

public record GetProductsByCategoryRequest(string Category, int? PageNumber = 1, int? PageSize = 15);