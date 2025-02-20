using CustomerApi.Customers.UpdateCustomer.RequestHandling;

namespace CustomerApi.Customers.UpdateCustomer.Endpoint;

public class UpdateCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/customers", 
            async (UpdateCustomerRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateCustomerCommand>();
                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<UpdateCustomerResponse>());
            })
            .WithName("CreateCustomer")
            .Produces<UpdateCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}