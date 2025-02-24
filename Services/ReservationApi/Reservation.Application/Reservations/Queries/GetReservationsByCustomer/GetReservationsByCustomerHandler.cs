namespace Reservation.Application.Reservations.Queries.GetReservationsByCustomer;

public class GetReservationsByCustomerHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetReservationByCustomerQuery, GetReservationsByCustomerResult>
{
    public async Task<GetReservationsByCustomerResult> Handle(GetReservationByCustomerQuery query, CancellationToken cancellationToken)
    {
        var reservations = await dbContext.Reservations
                        .Include(o => o.ReservationItem)
                        .AsNoTracking()
                        .Where(r => r.CustomerId == CustomerId.Of(query.CustomerId))
                        .OrderByDescending(r => r.Date)
                        .ToListAsync(cancellationToken);

        return new GetReservationsByCustomerResult(reservations.Adapt<IEnumerable<ReservationDto>>());        
    }
}
