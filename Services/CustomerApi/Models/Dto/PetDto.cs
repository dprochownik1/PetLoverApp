namespace CustomerApi.Models.Dto;

public record PetDto(
    Guid Id,
    Guid CustomerId,
    string Species,
    string Race,
    string Name,
    DateTime DateOfBirth,
    string ImageUrl);