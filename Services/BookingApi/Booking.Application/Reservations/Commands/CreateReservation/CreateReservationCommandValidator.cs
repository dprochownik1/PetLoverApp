namespace Booking.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.Reservation.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.Reservation.ReservationItem).NotNull().WithMessage("Reservation item cannot be null");
    }
}