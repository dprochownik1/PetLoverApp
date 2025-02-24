using Booking.Application.Reservations.Commands.DeleteReservation;

namespace BookingApi.Endpoints.DeleteReservation;

public class DeleteReservationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/reservations/{reservationId}",
                async ([AsParameters] DeleteReservationRequest request, ISender sender) =>
                {
                    var command = request.Adapt<DeleteReservationCommand>();
                    var result = await sender.Send(command);

                    return Results.Ok(result.Adapt<DeleteReservationResponse>());
                })
            .WithName("DeleteReservation")
            .Produces<DeleteReservationResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}