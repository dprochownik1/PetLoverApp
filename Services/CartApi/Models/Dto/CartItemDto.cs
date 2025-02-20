namespace CartApi.Models.Dto;

public record CartItemDto(
    Guid ProductId,
    string ProductName,
    decimal ProductPrice, 
    TimeSpan ProductDuration);