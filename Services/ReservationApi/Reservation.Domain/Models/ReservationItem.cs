namespace Reservation.Domain.Models;

public class ReservationItem : Entity<ReservationItemId>
{
    public ReservationId ReservationId { get; private set; } = default!;
    public ProductId ProductId { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    protected ReservationItem()
    {
    }

    private ReservationItem(ReservationItemId id, ReservationId reservationId, 
        ProductId productId, decimal price)
    {
        Id = id;
        ReservationId = reservationId;
        ProductId = productId;
        Price = price;
    }

    public static ReservationItem Create(ReservationItemId id,
        ReservationId reservationId, ProductId productId, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        return new ReservationItem(id, reservationId, productId, price);
    }
}