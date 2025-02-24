using Booking.Application.Reservations.Queries.GetReservationById;

namespace BookingApi.Endpoints.GetReservationById;

public class GetReservationByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/reservations/{reservationId}",
                async ([AsParameters] GetReservationByIdRequest request, ISender sender) =>
                {
                    var query = request.Adapt<GetReservationByIdQuery>();
                    var result = await sender.Send(query);

                    return Results.Ok(result.Adapt<GetReservationByIdResponse>());
                })
            .WithName("GetReservationById")
            .Produces<GetReservationByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}