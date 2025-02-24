namespace Booking.Application.Reservations.Queries.GetReservationsByCustomer;

public record GetReservationByCustomerQuery(Guid CustomerId) : IQuery<GetReservationsByCustomerResult>;