namespace Reservation.Domain.Events;

public record ReservationCreatedEvent(ReservationEntity Reservation) : IDomainEvent;
