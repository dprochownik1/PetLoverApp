namespace Booking.Application.Reservations.Queries.GetReservationById;

public record GetReservationByIdQuery(Guid ReservationId) : ICommand<GetReservationByIdResult>, IQuery<GetReservationByIdResult>;