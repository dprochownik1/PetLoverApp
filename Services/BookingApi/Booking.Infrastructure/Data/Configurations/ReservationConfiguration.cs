using Booking.Domain.Enums;

namespace Booking.Infrastructure.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasConversion(
            reservationId => reservationId.Value,
            dbId => ReservationId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(r => r.CustomerId)
            .IsRequired();

        builder.HasOne(r => r.ReservationItem)
            .WithOne()
            .HasForeignKey<ReservationItem>(r => r.ReservationId);

        builder.ComplexProperty(
            o => o.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.Name)
                    .HasMaxLength(20)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(20)
                    .IsRequired();

                addressBuilder.Property(a => a.EmailAddress)
                    .HasMaxLength(200);

                addressBuilder.Property(a => a.PhoneNumber)
                    .HasMaxLength(9);

                addressBuilder.Property(a => a.City)
                    .HasMaxLength(20)
                    .IsRequired();

                addressBuilder.Property(a => a.Street)
                    .HasMaxLength(40)
                    .IsRequired();

                addressBuilder.Property(a => a.Building)
                    .HasMaxLength(5)
                    .IsRequired();

                addressBuilder.Property(a => a.PostalCode)
                    .HasMaxLength(6)
                    .IsRequired();

                addressBuilder.Property(a => a.Flat)
                    .HasMaxLength(5);
            });

        builder.ComplexProperty(
            o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(p => p.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                paymentBuilder.Property(p => p.Expiration)
                    .HasMaxLength(10);

                paymentBuilder.Property(p => p.Cvv)
                    .HasMaxLength(3);
            });

        builder.Property(o => o.Status)
            .HasDefaultValue(ReservationStatus.Pending)
            .HasConversion(
                s => s.ToString(), 
                dbStatus => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), dbStatus));
    }
}