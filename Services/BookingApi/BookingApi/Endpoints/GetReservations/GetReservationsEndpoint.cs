using Booking.Application.Reservations.Queries.GetReservations;

namespace BookingApi.Endpoints.GetReservations;

public class GetReservationsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var producesValidationProblem = app.MapGet("/reservations",
                async ([AsParameters] PaginationRequest request, ISender sender) =>
                {
                    var query = new GetReservationsQuery(request);
                    var result = await sender.Send(query);

                    return Results.Ok(result.Adapt<GetReservationsResponse>());
                })
            .WithName("GetReservations")
            .Produces<GetReservationsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}