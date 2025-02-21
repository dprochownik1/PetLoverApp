using Reservation.Domain.ValueObjects;

namespace Reservation.Infrastructure.Data.Configurations;

public class ReservationItemConfiguration : IEntityTypeConfiguration<ReservationItem>
{
    public void Configure(EntityTypeBuilder<ReservationItem> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id).HasConversion(
            itemId => itemId.Value,
            dbId => ReservationItemId.Of(dbId));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        builder.Property(oi => oi.Price).IsRequired();
    }
}