namespace CartApi.Models.Dto;

public record CartDto(
    Guid CustomerId, 
    ICollection<CartItemDto> Items);