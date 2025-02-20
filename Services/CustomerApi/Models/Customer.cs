namespace CustomerApi.Models;

public class Customer
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public Address Address { get; set; } = default!;
}