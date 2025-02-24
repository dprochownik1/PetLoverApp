namespace Reservation.Application.Reservations.Commands.UpdateReservation;
public record UpdateReservationCommand(ReservationDto Reservation)
    : ICommand<UpdateReservationResult>;