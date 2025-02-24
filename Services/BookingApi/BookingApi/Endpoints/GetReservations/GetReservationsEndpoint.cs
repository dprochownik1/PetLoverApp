using Booking.Application.Reservations.Queries.GetReservations;

namespace BookingApi.Endpoints.GetReservations;

public class GetReservationsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/reservations",
                async ([AsParameters] GetReservationsRequest request, ISender sender) =>
                {
                    var query = request.Adapt<GetReservationsQuery>();
                    var result = await sender.Send(query);

                    return Results.Ok(result.Adapt<GetReservationsResponse>());
                })
            .WithName("GetReservations")
            .Produces<GetReservationsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}