namespace Booking.Application.Reservations.Queries.GetReservations;

public record GetReservationsResult(PaginatedResult<ReservationDto> Reservations);