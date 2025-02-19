namespace ProductApi.Models.Dto;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    string Category,
    string ImageFile,
    decimal Price,
    TimeSpan Duration);
