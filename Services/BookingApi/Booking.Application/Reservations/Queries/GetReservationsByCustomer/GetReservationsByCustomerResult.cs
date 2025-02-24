using Booking.Application.Dto;

namespace Booking.Application.Reservations.Queries.GetReservationsByCustomer;

public record GetReservationsByCustomerResult(IEnumerable<ReservationDto> Reservations);