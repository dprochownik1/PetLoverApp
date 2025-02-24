using Booking.Application.Reservations.Commands.UpdateReservation;

namespace BookingApi.Endpoints.UpdateReservation;

public class UpdateReservationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/reservations",
                async (UpdateReservationRequest request, ISender sender) => 
                 {
                     var query = request.Adapt<UpdateReservationCommand>();
                     var result = await sender.Send(query);

                     return Results.Ok(result.Adapt<UpdateReservationResponse>());
                 })
            .WithName("UpdateReservation")
            .Produces<UpdateReservationResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}