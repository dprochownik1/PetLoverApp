using ProductApi.Products.DeleteProduct.RequestHandling;

namespace ProductApi.Products.DeleteProduct.Endpoint;

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async ([AsParameters] DeleteProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeleteProductCommand>();
                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<DeleteProductResponse>());
            })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}