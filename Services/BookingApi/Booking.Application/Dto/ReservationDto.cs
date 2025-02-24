using Booking.Domain.Enums;

namespace Booking.Application.Dto;

public record ReservationDto(
    Guid Id,
    Guid CustomerId,
    ReservationItemDto ReservationItem,
    AddressDto BillingAddress,
    PaymentDto Payment,
    ReservationStatus Status,
    DateTime Date);