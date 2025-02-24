namespace Booking.Application.Dto;

public record ReservationItemDto(
    Guid Id,
    Guid ReservationId,
    Guid ProductId,
    decimal Price);