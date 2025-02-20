namespace CustomerApi.Models.Dto;

public record GetPetsByCustomerResponseDto(IEnumerable<PetDto> Pets);