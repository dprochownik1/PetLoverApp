using PetApi.Pets.DeletePetsByCustomer.RequestHandling;

namespace PetApi.Pets.DeletePetsByCustomer.Endpoint;

public class DeletePetsByCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/pets/customer/{customerId}",
                async ([AsParameters] DeletePetsByCustomerRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeletePetsByCustomerCommand>();
                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<DeletePetsByCustomerResponse>());
            })
            .WithName("DeletePet")
            .Produces<DeletePetsByCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}