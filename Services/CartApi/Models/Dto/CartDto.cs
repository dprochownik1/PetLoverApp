namespace CartApi.Models.Dto;

public record CartDto(
    Guid Id,
    Guid CustomerId, 
    ICollection<CartItemDto> Items);