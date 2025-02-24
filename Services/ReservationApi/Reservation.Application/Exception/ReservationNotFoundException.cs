namespace Reservation.Application.Exception;

public class ReservationNotFoundException : NotFoundException
{
    public ReservationNotFoundException(Guid reservationId) : base("Reservation", reservationId)
    {
    }
}