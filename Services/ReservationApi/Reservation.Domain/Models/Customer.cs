namespace Reservation.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;

    public static Customer Create(CustomerId id, string name, string lastName, string emailAddress)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);

        return new Customer
        {
            Id = id,
            Name = name,
            LastName = lastName,
            EmailAddress = emailAddress
        };
    }
}