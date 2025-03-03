using CartApi.Carts.StoreCart.RequestHandling;

namespace CartApi.Carts.StoreCart.Endpoint;

public class StoreCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/cart",
                async (StoreCartRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreCartCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<StoreCartResponse>();

                return Results.Created($"/cart/{response.CustomerId}", response);
            })
            .WithName("StoreCartAsync")
            .Produces<StoreCartResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}
