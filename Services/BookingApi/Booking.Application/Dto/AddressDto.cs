namespace Booking.Application.Dto;

public record AddressDto(
    string Name,
    string LastName,
    string EmailAddress,
    string PhoneNumber,
    string City,
    string Street,
    string Building,
    string Flat,
    string PostalCode);