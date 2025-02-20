using CustomerApi.Customers.GetCustomerById.RequestHandling;

namespace CustomerApi.Customers.GetCustomerById.Endpoint;

public class GetCustomerByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers/{customerId}", async ([AsParameters] GetCustomerByIdRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetCustomerByIdQuery>();
                var result = await sender.Send(query);

                return Results.Ok(result.Adapt<GetCustomerByIdResponse>());
            })
            .WithName("GetCustomerById")
            .Produces<GetCustomerByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}