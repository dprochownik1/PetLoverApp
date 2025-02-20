namespace CustomerApi.Models.Dto;

public record CustomerProfileDto(
    CustomerDto Customer,
    IEnumerable<PetDto> Pets);