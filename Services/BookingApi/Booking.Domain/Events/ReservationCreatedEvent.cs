using Booking.Domain.Abstractions;

namespace Booking.Domain.Events;

public record ReservationCreatedEvent(ReservationModel Reservation) : IDomainEvent;
