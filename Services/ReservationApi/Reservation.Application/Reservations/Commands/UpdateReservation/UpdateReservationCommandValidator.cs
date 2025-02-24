namespace Reservation.Application.Reservations.Commands.UpdateReservation;

public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(x => x.Reservation.Id).NotEmpty().WithMessage("Id is required");
    }
}