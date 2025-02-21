namespace Reservation.Domain.ValueObjects;

public record Payment
{
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;

    protected Payment()
    {
    }

    private Payment(string cardNumber, string expiration, string cvv)
    {
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
    }

    public static Payment Of(string cardNumber, string expiration, string cvv)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        DomainException.ThrowIfNotAllCharsAreDigit(cardNumber);
        ArgumentOutOfRangeException.ThrowIfNotEqual(cardNumber.Length, 24);

        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        DomainException.ThrowIfNotAllCharsAreDigit(cvv);
        ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, 3);
        
        ArgumentException.ThrowIfNullOrWhiteSpace(expiration);

        return new Payment(cardNumber, expiration, cvv);
    }
}