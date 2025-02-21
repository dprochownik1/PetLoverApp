namespace Reservation.Domain.Events;

public record ReservationCreatedEvent(ReservationAggregate Reservation) : IDomainEvent;
