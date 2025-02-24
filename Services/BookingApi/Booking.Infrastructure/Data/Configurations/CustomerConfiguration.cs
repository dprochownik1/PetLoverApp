namespace Booking.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            dbId => CustomerId.Of(dbId));
        builder.Property(c => c.Name).HasMaxLength(20).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(20).IsRequired();
        builder.Property(c => c.EmailAddress).HasMaxLength(200);
        builder.HasIndex(c => c.EmailAddress).IsUnique();
    }
}