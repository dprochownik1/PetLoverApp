namespace CartApi.Models.Dto;

public record CartCheckoutDto(
    Guid CustomerId,
    CartItemDto CartItem,
    AddressDto Address,
    PaymentDto Payment,
    DateTime Date);