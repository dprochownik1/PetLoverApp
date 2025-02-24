using Booking.Application.Dto;

namespace Booking.Application.Reservations.Commands.CreateReservation;

public record CreateReservationCommand(ReservationDto Reservation) : ICommand<CreateReservationResult>;