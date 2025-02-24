using Booking.Application.Dto;

namespace Booking.Application.Reservations.Commands.UpdateReservation;

public record UpdateReservationCommand(UpdateReservationDto Reservation) : ICommand<UpdateReservationResult>;