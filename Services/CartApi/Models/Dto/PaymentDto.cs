namespace CartApi.Models.Dto;

public record PaymentDto(
    string CardNumber,
    string Expiration,
    string Cvv);