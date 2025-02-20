namespace CustomerApi.Models.Dto;

public record CreateCustomerDto(
    Guid CustomerId,
    string Name,
    string LastName,
    string PhoneNumber,
    string EmailAddress,
    AddressDto Address);
