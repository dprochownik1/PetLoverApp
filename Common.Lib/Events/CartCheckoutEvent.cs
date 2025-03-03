namespace Common.Lib.Messaging.Events;

public record CartCheckoutEvent : IntegrationEvent
{
    public Guid CustomerId { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string Building { get; set; } = default!;
    public string Flat { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string CardNumber { get; set; } = default!;
    public string Expiration { get; set; } = default!;
    public string Cvv { get; set; } = default!;
}