namespace CustomerApi.Models.Dto;

public record UpdateCustomerDto(
Guid Id,
string Name,
string LastName,
string PhoneNumber,
string EmailAddress,
AddressDto Address);