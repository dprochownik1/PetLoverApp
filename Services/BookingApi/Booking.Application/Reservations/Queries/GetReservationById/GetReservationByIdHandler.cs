namespace Booking.Application.Reservations.Queries.GetReservationById;

public class GetReservationByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetReservationByIdQuery, GetReservationByIdResult>
{
    public async Task<GetReservationByIdResult> Handle(GetReservationByIdQuery query, CancellationToken cancellationToken)
    {
        var reservation = await dbContext.Reservations.SingleOrDefaultAsync(
            r => r.Id == ReservationId.Of(query.ReservationId), cancellationToken);

        return reservation != null
            ? new GetReservationByIdResult(reservation.Adapt<ReservationDto>())
            : throw new ReservationNotFoundException(query.ReservationId);
    }
}