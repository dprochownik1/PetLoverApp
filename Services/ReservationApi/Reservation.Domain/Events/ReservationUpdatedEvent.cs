namespace Reservation.Domain.Events;

public record ReservationUpdatedEvent(ReservationModel Reservation) : IDomainEvent;