namespace Reservation.Application.Reservations.Queries.GetReservations;

public record GetReservationsQuery(PaginationRequest PaginationRequest) : IQuery<GetReservationsResult>;