using Booking.Domain.Enums;
using Common.Lib.Events;

namespace Booking.Application.Extensions;

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

        TypeAdapterConfig<ReservationDto, Reservation>
            .NewConfig()
            .ConstructUsing(dto => Reservation.Create(
                ReservationId.Of(dto.Id),
                CustomerId.Of(dto.CustomerId),
                dto.ReservationItem.Adapt<ReservationItem>(),
                dto.BillingAddress.Adapt<Address>(),
                dto.Payment.Adapt<Payment>(),
                dto.Date
            ));

        TypeAdapterConfig<CartCheckoutEvent, ReservationDto>
            .NewConfig()
            .ConstructUsing(checkoutEvent => MapCartCheckoutEvent(checkoutEvent));
        
        TypeAdapterConfig<ReservationItem, ReservationItemDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.ReservationId, src => src.ReservationId.Value)
            .Map(dest => dest.ProductId, src => src.ProductId.Value);

        TypeAdapterConfig<ReservationDto, Reservation>
            .NewConfig()
            .Map(dest => dest.Id, src => ReservationId.Of(src.Id))
            .Map(dest => dest.CustomerId, src => CustomerId.Of(src.CustomerId));
    }

    private static ReservationDto MapCartCheckoutEvent(CartCheckoutEvent checkoutEvent)
    {
        var reservationId = Guid.NewGuid();

        var reservationItem = new ReservationItemDto(
            Guid.NewGuid(),
            reservationId,
            checkoutEvent.ProductId,
            checkoutEvent.ProductPrice);

        var address = new AddressDto(
            checkoutEvent.Name,
            checkoutEvent.LastName,
            checkoutEvent.EmailAddress,
            checkoutEvent.PhoneNumber,
            checkoutEvent.City,
            checkoutEvent.Street,
            checkoutEvent.Building,
            checkoutEvent.Flat,
            checkoutEvent.PostalCode);

        var payment = new PaymentDto(
            checkoutEvent.CardNumber,
            checkoutEvent.Expiration,
            checkoutEvent.Cvv);

        return new ReservationDto(
            reservationId,
            Guid.NewGuid(),
            reservationItem,
            address,
            payment,
            ReservationStatus.Pending,
            checkoutEvent.Date);
    }
}