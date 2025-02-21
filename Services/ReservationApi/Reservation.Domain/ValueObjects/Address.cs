namespace Reservation.Domain.ValueObjects;

public record Address
{
    public string Name { get; } = default!;
    public string LastName { get; } = default!;
    public string EmailAddress { get; } = default!;
    public string City { get; } = default!;
    public string Street { get; } = default!;
    public string Building { get; } = default!;
    public string Flat { get; } = default!;
    public string PostalCode { get; } = default!;

    protected Address()
    {
    }

    private Address(string name, string lastName, string emailAddress, string city,
        string street, string building, string flat, string postalCode)
    {
        Name = name;
        LastName = lastName;
        EmailAddress = emailAddress;
        City = city;
        Street = street;
        Building = building;
        Flat = flat;
        PostalCode = postalCode;
    }

    public static Address Of(string name, string lastName, string emailAddress, string city,
        string street, string building, string flat, string postalCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        ArgumentException.ThrowIfNullOrWhiteSpace(building);
        ArgumentException.ThrowIfNullOrWhiteSpace(postalCode);

        return new Address(name, lastName, emailAddress, city, street, building, flat, postalCode);
    }
}