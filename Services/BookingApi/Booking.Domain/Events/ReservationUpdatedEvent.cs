using Booking.Domain.Abstractions;

namespace Booking.Domain.Events;

public record ReservationUpdatedEvent(ReservationModel Reservation) : IDomainEvent;