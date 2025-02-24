namespace Booking.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Product> Products { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<ReservationItem> ReservationItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}