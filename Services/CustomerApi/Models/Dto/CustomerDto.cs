namespace CustomerApi.Models.Dto;

public record CustomerDto(
    Guid Id,
    Guid UserId,
    string Name,
    string LastName,
    string PhoneNumber,
    string EmailAddress,
    AddressDto Address);