namespace Reservation.Domain.Events;

public record ReservationCreatedEvent(ReservationModel Reservation) : IDomainEvent;
