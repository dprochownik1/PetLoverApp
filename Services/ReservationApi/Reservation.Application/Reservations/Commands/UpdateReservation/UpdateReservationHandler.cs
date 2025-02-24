using Reservation.Application.Exception;

namespace Reservation.Application.Reservations.Commands.UpdateReservation;
public class UpdateReservationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateReservationCommand, UpdateReservationResult>
{
    public async Task<UpdateReservationResult> Handle(UpdateReservationCommand command, CancellationToken cancellationToken)
    {
        var reservationId = ReservationId.Of(command.Reservation.Id);
        var reservation = await dbContext.Reservations
            .FindAsync([reservationId], cancellationToken: cancellationToken);

        if (reservation is null)
            throw new ReservationNotFoundException(command.Reservation.Id);
        
        UpdateReservationWithNewValues(reservation, command.Reservation);

        dbContext.Reservations.Update(reservation);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateReservationResult(true);        
    }

    public static void UpdateReservationWithNewValues(ReservationModel reservation, ReservationDto reservationDto)
    {
        var addressDto = reservationDto.BillingAddress;
        var paymentDto = reservationDto.Payment;
        var updatedBillingAddress = Address.Of(addressDto.Name, addressDto.LastName, addressDto.EmailAddress,
            addressDto.PhoneNumber, addressDto.City, addressDto.Street, addressDto.Building, addressDto.Flat, addressDto.PostalCode );
        var updatedPayment = Payment.Of(paymentDto.CardNumber, paymentDto.Expiration, paymentDto.Cvv);

        reservation.Update(
            updatedBillingAddress,
            updatedPayment,
            reservationDto.Date,
            reservationDto.Status);
    }
}
