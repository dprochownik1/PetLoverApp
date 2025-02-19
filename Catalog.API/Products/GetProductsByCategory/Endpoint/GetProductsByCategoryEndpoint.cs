using ProductApi.Products.GetProductsByCategory.RequestHandling;

namespace ProductApi.Products.GetProductsByCategory.Endpoint;

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async ([AsParameters] GetProductsByCategoryRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsByCategoryQuery>();
                var result = await sender.Send(query);

                return Results.Ok(result.Adapt<GetProductsByCategoryResponse>());
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductsByCategoryResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}