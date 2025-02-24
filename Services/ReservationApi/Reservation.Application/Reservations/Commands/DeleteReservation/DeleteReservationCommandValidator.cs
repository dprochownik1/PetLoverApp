namespace Reservation.Application.Reservations.Commands.DeleteReservation;

public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(x => x.ReservationId).NotEmpty().WithMessage("ReservationId is required");
    }
}