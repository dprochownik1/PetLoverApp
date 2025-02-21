namespace Reservation.Domain.Events;

public record ReservationUpdatedEvent(ReservationEntity Reservation) : IDomainEvent;