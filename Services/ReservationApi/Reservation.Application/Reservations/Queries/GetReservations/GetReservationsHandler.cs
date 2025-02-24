namespace Reservation.Application.Reservations.Queries.GetReservations;

public class GetReservationsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetReservationsQuery, GetReservationsResult>
{
    public async Task<GetReservationsResult> Handle(GetReservationsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Reservations.LongCountAsync(cancellationToken);

        var reservations = await dbContext.Reservations
                       .Include(r => r.ReservationItem)
                       .AsNoTracking()
                       .OrderByDescending(r => r.Date)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetReservationsResult(
            new PaginatedResult<ReservationDto>(
                pageIndex,
                pageSize,
                totalCount,
                reservations.Adapt<IEnumerable<ReservationDto>>()));        
    }
}
