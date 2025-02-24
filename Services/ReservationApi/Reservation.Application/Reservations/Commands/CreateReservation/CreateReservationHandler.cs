namespace Reservation.Application.Reservations.Commands.CreateReservation;

public class CreateReservationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateReservationCommand, CreateReservationResult>
{
    public async Task<CreateReservationResult> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {
        var reservation = CreateReservation(command.Reservation);

        dbContext.Reservations.Add(reservation);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateReservationResult(reservation.Id.Value);
    }

    private static ReservationModel CreateReservation(ReservationDto reservationDto)
    {
        var addressDto = reservationDto.BillingAddress;
        var paymentDto = reservationDto.Payment;
        var reservationItemDto = reservationDto.ReservationItem;

        var billingAddress = Address.Of(addressDto.Name, addressDto.LastName,
            addressDto.EmailAddress, addressDto.PhoneNumber, addressDto.City,
            addressDto.Street, addressDto.Building, addressDto.Flat, addressDto.PostalCode);

        var reservationId = ReservationId.Of(Guid.NewGuid());

        var reservationItem = ReservationItem.Create(
            ReservationItemId.Of(Guid.NewGuid()),
            reservationId,
            ProductId.Of(reservationItemDto.Id),
            reservationItemDto.Price);

        return ReservationModel.Create(
            reservationId,
            CustomerId.Of(reservationDto.CustomerId),
            reservationItem, 
            billingAddress,
            Payment.Of(paymentDto.CardNumber, paymentDto.Expiration, paymentDto.Cvv),
            reservationDto.Date);
    }
}
