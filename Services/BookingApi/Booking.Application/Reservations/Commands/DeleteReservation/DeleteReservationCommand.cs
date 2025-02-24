namespace Booking.Application.Reservations.Commands.DeleteReservation;

public record DeleteReservationCommand(Guid ReservationId) : ICommand<DeleteReservationResult>;