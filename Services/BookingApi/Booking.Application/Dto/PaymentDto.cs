namespace Booking.Application.Dto;

public record PaymentDto(
    string CardNumber,
    string Expiration,
    string Cvv);