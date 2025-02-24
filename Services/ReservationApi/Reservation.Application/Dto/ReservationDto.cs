using Reservation.Domain.Enums;

namespace Reservation.Application.Dto;

public record ReservationDto(
    Guid Id,
    Guid CustomerId,
    ReservationItemDto ReservationItem,
    AddressDto BillingAddress,
    PaymentDto Payment,
    ReservationStatus Status,
    DateTime Date);