using Booking.Application.Data;
using Booking.Application.Exception;
using Booking.Domain.ValueObjects;

namespace Booking.Application.Reservations.Commands.DeleteReservation;
public class DeleteReservationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteReservationCommand, DeleteReservationResult>
{
    public async Task<DeleteReservationResult> Handle(DeleteReservationCommand command, CancellationToken cancellationToken)
    {
        //Delete Reservation entity from command object
        //save to database
        //return result

        var reservationId = ReservationId.Of(command.ReservationId);
        var reservation = await dbContext.Reservations
            .FindAsync([reservationId], cancellationToken: cancellationToken);

        if (reservation is null)
        {
            throw new ReservationNotFoundException(command.ReservationId);
        }

        dbContext.Reservations.Remove(reservation);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteReservationResult(true);        
    }
}
