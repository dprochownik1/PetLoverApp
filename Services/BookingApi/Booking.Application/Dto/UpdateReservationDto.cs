using Booking.Domain.Enums;

namespace Booking.Application.Dto;

public record UpdateReservationDto(
    Guid Id,
    AddressDto BillingAddress,
    PaymentDto Payment,
    DateTime Date,
    ReservationStatus Status);