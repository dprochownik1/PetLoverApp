namespace Reservation.Application.Reservations.Commands.CreateReservation;

public record CreateReservationCommand(ReservationDto Reservation) : ICommand<CreateReservationResult>;