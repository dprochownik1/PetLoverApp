namespace Reservation.Application.Reservations.Queries.GetReservationsByCustomer;

public record GetReservationByCustomerQuery(Guid CustomerId) : IQuery<GetReservationsByCustomerResult>;