namespace Reservation.Domain.ValueObjects;

public record ReservationId
{
    public Guid Value { get; }

    private ReservationId(Guid value) => Value = value;

    public static ReservationId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) throw new DomainException("ReservationId cannot be empty.");

        return new ReservationId(value);
    }
}