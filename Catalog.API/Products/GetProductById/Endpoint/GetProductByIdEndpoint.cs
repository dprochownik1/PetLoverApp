using Catalog.API.Products.GetProductById.RequestHandling;

namespace Catalog.API.Products.GetProductById.Endpoint;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async ([AsParameters] GetProductByIdRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductByIdQuery>();
                var result = await sender.Send(query);

                return Results.Ok(result.Adapt<GetProductByIdResponse>());
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}