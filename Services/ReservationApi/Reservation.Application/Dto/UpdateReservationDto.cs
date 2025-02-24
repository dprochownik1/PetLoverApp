using Reservation.Domain.Enums;

namespace Reservation.Application.Dto;

public record UpdateReservationDto(
    Guid Id,
    AddressDto BillingAddress,
    PaymentDto Payment,
    DateTime Date,
    ReservationStatus Status)