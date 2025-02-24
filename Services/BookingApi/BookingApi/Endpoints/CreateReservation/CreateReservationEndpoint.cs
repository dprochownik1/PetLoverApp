using Booking.Application.Reservations.Commands.CreateReservation;

namespace BookingApi.Endpoints.CreateReservation;

public class CreateReservationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/reservations",
                async (CreateReservationRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateReservationCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<CreateReservationResponse>();

                    return Results.Created($"customers/{response.ReservationId}", response);
                })
            .WithName("CreateReservation")
            .Produces<CreateReservationResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}