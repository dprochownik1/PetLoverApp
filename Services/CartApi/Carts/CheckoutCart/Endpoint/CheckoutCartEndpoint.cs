using CartApi.Carts.CheckoutCart.RequestHandling;

namespace CartApi.Carts.CheckoutCart.Endpoint;

public class CheckoutCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/cart/checkout",
                async (CheckoutCartRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CheckoutCartCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<CheckoutCartResponse>();

                    return Results.Ok(response);
                })
            .WithName("CartCheckout")
            .Produces<CheckoutCartResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}