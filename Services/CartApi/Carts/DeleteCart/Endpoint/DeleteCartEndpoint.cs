using CartApi.Carts.DeleteCart.RequestHandling;

namespace CartApi.Carts.DeleteCart.Endpoint;

public class DeleteCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cart/{customerId}",
                async ([AsParameters] DeleteCartRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeleteCartCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<DeleteCartResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteCartAsync")
            .Produces<DeleteCartResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}
