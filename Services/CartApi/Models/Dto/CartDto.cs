namespace CartApi.Models.Dto;

public record CartDto(
    Guid CustomerId, 
    IEnumerable<CartItemDto> Items);