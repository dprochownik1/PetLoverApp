using PetApi.Pets.GetPetsByCustomer.RequestHandling;

namespace PetApi.Pets.GetPetsByCustomer.Endpoint;

public class GetPetsByCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async ([AsParameters] GetPetsByCustomerRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetPetsByCustomerQuery>();
                var result = await sender.Send(query);

                return Results.Ok(result.Adapt<GetPetsByCustomerResponse>());
            })
            .WithName("GetPetsByCustomer")
            .Produces<GetPetsByCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}