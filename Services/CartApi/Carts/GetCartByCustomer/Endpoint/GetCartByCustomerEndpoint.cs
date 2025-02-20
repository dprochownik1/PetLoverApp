using CartApi.Carts.GetCartByCustomer.RequestHandling;

namespace CartApi.Carts.GetCartByCustomer.Endpoint;

public class GetCartByCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cart/{customerId}",
                async ([AsParameters] GetCartByCustomerRequest request, ISender sender) =>
            {
                var command = request.Adapt<GetCartByCustomerQuery>();
                var result = await sender.Send(command);

                var response = result.Adapt<GetCartByCustomerResponse>();

                return Results.Ok(response);
            })
            .WithName("GetCartByCustomer")
            .Produces<GetCartByCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}
