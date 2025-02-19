using PetApi.Pets.CreatePet.RequestHandling;

namespace PetApi.Pets.CreatePet.Endpoint;

public class CreatePetEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("pets", async (CreatePetRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreatePetCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreatePetResponse>();

                return Results.Created($"pets/{response.Id}", response);
            })
            .WithName("CreatePet")
            .Produces<CreatePetResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}