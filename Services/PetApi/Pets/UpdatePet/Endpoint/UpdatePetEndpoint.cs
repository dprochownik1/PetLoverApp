using PetApi.Pets.UpdatePet.RequestHandling;

namespace PetApi.Pets.UpdatePet.Endpoint;

public class UpdatePetEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/pets", async (UpdatePetRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdatePetCommand>();
                var result = await sender.Send(command);

                return Results.Ok(result.Adapt<UpdatePetResponse>());
            })
            .WithName("UpdatePet")
            .Produces<UpdatePetResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}