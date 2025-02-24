using Booking.Application.Reservations.Queries.GetReservationsByCustomer;

namespace BookingApi.Endpoints.GetReservationsByCustomer;

public class GetReservationsByCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/reservations/customers/{customerId}",
                async ([AsParameters] GetReservationsByCustomerRequest request, ISender sender) =>
                {
                    var query = request.Adapt<GetReservationByCustomerQuery>();
                    var result = await sender.Send(query);

                    return Results.Ok(result.Adapt<GetReservationsByCustomerResponse>());
                })
            .WithName("GetReservationByCustomer")
            .Produces<GetReservationsByCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}