namespace CartApi.Configuration;

internal static class MappingConfiguration
{
    internal static void RegisterMaps()
    {
        TypeAdapterConfig<CartCheckoutDto, CartCheckoutEvent>
            .NewConfig()
            .ConstructUsing(dto => new CartCheckoutEvent
            {
                CustomerId = dto.CustomerId,
                ProductId = dto.CartItem.ProductId,
                ProductName = dto.CartItem.ProductName,
                ProductPrice = dto.CartItem.ProductPrice,
                ProductDuration = dto.CartItem.ProductDuration,
                Name = dto.Address.Name,
                LastName = dto.Address.LastName,
                EmailAddress = dto.Address.EmailAddress,
                PhoneNumber = dto.Address.PhoneNumber,
                City = dto.Address.City,
                Street = dto.Address.Street,
                Building = dto.Address.Building,
                Flat = dto.Address.Flat,
                PostalCode = dto.Address.PostalCode,
                CardNumber = dto.Payment.CardNumber,
                Expiration = dto.Payment.Expiration,
                Cvv = dto.Payment.Cvv,
                Date = dto.Date
            });
    }
}