namespace BookingApi.Endpoints.GetReservations;

public record GetReservationsResponse(PaginatedResult<ReservationDto> Reservations);