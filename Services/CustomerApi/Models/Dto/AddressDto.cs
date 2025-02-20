namespace CustomerApi.Models.Dto;

public record AddressDto(
    string City,
    string Street,
    string Building,
    string Flat,
    string PostalCode);