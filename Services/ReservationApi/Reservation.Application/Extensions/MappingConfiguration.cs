namespace Reservation.Application.Extensions;

internal static class MappingConfiguration
{
    internal static void RegisterMaps()
    {
        TypeAdapterConfig<ReservationItemDto, ReservationItem>
            .NewConfig()
            .ConstructUsing(dto => ReservationItem.Create(
                ReservationItemId.Of(dto.Id),
                ReservationId.Of(dto.ReservationId),
                ProductId.Of(dto.ProductId),
                dto.Price));

        TypeAdapterConfig<AddressDto, Address>
            .NewConfig()
            .ConstructUsing(dto => Address.Of(
                dto.Name,
                dto.LastName,
                dto.EmailAddress,
                dto.PhoneNumber,
                dto.City,
                dto.Street,
                dto.Building,
                dto.Flat,
                dto.PostalCode));

        TypeAdapterConfig<PaymentDto, Payment>
            .NewConfig()
            .ConstructUsing(dto => Payment.Of(
                dto.CardNumber,
                dto.Expiration,
                dto.Cvv));

        TypeAdapterConfig<ReservationDto, ReservationModel>
            .NewConfig()
            .ConstructUsing(dto => ReservationModel.Create(
                ReservationId.Of(dto.Id),
                CustomerId.Of(dto.CustomerId),
                dto.ReservationItem.Adapt<ReservationItem>(),
                dto.BillingAddress.Adapt<Address>(),
                dto.Payment.Adapt<Payment>(),
                dto.Date
            ));

        TypeAdapterConfig<ReservationItem, ReservationItemDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.ReservationId, src => src.ReservationId.Value)
            .Map(dest => dest.ProductId, src => src.ProductId.Value);

        TypeAdapterConfig<ReservationDto, ReservationModel>
            .NewConfig()
            .Map(dest => dest.Id, src => ReservationId.Of(src.Id))
            .Map(dest => dest.CustomerId, src => CustomerId.Of(src.CustomerId));
    }
}