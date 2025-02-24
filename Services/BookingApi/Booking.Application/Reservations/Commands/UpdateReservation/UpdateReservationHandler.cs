using Booking.Application.Data;
using Booking.Application.Exception;
using Booking.Domain.ValueObjects;

namespace Booking.Application.Reservations.Commands.UpdateReservation;

public class UpdateReservationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateReservationCommand, UpdateReservationResult>
{
    public async Task<UpdateReservationResult> Handle(UpdateReservationCommand command, CancellationToken cancellationToken)
    {
        var reservationDto = command.Reservation;
        var reservation = await dbContext.Reservations
            .FindAsync([ReservationId.Of(reservationDto.Id)], cancellationToken);

        if (reservation is null) throw new ReservationNotFoundException(command.Reservation.Id);

        reservation.Update(
            reservationDto.BillingAddress.Adapt<Address>(),
            reservationDto.Payment.Adapt<Payment>(),
            reservationDto.Date,
            reservationDto.Status);

        dbContext.Reservations.Update(reservation);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateReservationResult(true);
    }
}
