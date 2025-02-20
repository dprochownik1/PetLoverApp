using PetApi.Pets.GetPets.RequestHandling;

namespace PetApi.Pets.GetPets.Endpoint;

public class GetPetsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/pets", async (ISender sender) =>
            {
                var result = await sender.Send(new GetPetsQuery());

                return Results.Ok(result.Adapt<GetPetsResponse>());
            })
            .WithName("GetPets")
            .Produces<GetPetsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}