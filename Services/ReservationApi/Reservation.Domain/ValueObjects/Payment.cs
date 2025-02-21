namespace Reservation.Domain.ValueObjects;

public record Payment
{
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;

    protected Payment()
    {
    }

    private Payment(string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(expiration);
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, 3);

        return new Payment(cardNumber, expiration, cvv, paymentMethod);
    }
}