using CustomerApi.Customers.CreateCustomer.RequestHandling;

namespace CustomerApi.Customers.CreateCustomer.Endpoint;

public class CreateCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", 
            async (CreateCustomerRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateCustomerCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateCustomerResponse>();

                return Results.Created($"customers/{response.CustomerId}", response);
            })
            .WithName("CreateCustomer")
            .Produces<CreateCustomerResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}