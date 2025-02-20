using CustomerApi.Customers.DeleteCustomer.RequestHandling;

namespace CustomerApi.Customers.DeleteCustomer.Endpoint;

public class DeleteCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/customers/{id}", async ([AsParameters] DeleteCustomerRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeleteCustomerCommand>();
                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<DeleteCustomerResponse>());
            })
            .WithName("DeleteCustomer")
            .Produces<DeleteCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}