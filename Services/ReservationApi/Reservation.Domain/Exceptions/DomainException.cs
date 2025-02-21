namespace Reservation.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }

    public static void ThrowIfNotAllCharsAreDigit(string value)
    {
        if (!value.All(char.IsDigit))
        {
            throw new DomainException($"String: {value} is not convertible to a number");
        }
    }
}