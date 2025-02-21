namespace Reservation.Domain.ValueObjects;

public record ReservationItemId
{
    public Guid Value { get; }

    private ReservationItemId(Guid value) => Value = value;

    public static ReservationItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) throw new DomainException("ReservationItemId cannot be empty.");

        return new ReservationItemId(value);
    }
}