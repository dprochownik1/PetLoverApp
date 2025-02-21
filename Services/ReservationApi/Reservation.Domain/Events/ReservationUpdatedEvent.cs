namespace Reservation.Domain.Events;

public record ReservationUpdatedEvent(ReservationAggregate Reservation) : IDomainEvent;