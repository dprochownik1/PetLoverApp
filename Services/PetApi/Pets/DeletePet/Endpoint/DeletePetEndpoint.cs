using PetApi.Pets.DeletePet.RequestHandling;

namespace PetApi.Pets.DeletePet.Endpoint;

public class DeletePetEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/pets/{id}", async ([AsParameters] DeletePetRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeletePetCommand>();
                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<DeletePetResponse>());
            })
            .WithName("DeletePet")
            .Produces<DeletePetResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}