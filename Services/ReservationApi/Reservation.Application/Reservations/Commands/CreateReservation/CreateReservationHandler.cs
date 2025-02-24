namespace Reservation.Application.Reservations.Commands.CreateReservation;

public class CreateReservationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateReservationCommand, CreateReservationResult>
{
    public async Task<CreateReservationResult> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {
        var reservation = command.Reservation.Adapt<ReservationModel>();

        dbContext.Reservations.Add(reservation);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateReservationResult(reservation.Id.Value);
    }
}
