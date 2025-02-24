namespace Reservation.Application.Dto;

public record PaymentDto(
    string CardNumber,
    string Expiration,
    string Cvv);