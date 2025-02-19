using PetApi.Pets.GetPetById.RequestHandling;

namespace PetApi.Pets.GetPetById.Endpoint;

public class GetPetByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/pets/{id}", async ([AsParameters] GetPetByIdRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetPetByIdQuery>();
                var result = await sender.Send(query);

                return Results.Ok(result.Adapt<GetPetByIdResponse>());
            })
            .WithName("GetPetById")
            .Produces<GetPetByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}