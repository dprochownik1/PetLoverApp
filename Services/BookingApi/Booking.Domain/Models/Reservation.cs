using Booking.Domain.Abstractions;
using Booking.Domain.Enums;
using Booking.Domain.Events;
using Booking.Domain.ValueObjects;

namespace Booking.Domain.Models;

public class Reservation : Aggregate<ReservationId>
{
    public CustomerId CustomerId { get; private set; } = default!;
    public ReservationItem ReservationItem { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public DateTime Date { get; private set; } = default!;
    public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;

    public static ReservationModel Create(ReservationId id, CustomerId customerId,
        ReservationItem item, Address billingAddress, Payment payment, DateTime date)
    {
        var reservation = new ReservationModel
        {
            Id = id,
            CustomerId = customerId,
            ReservationItem = item,
            BillingAddress = billingAddress,
            Payment = payment,
            Date = date,
            Status = ReservationStatus.Pending
        };

        reservation.AddDomainEvent(new ReservationCreatedEvent(reservation));

        return reservation;
    }

    public void Update(Address billingAddress, Payment payment, DateTime date, ReservationStatus status)
    {
        BillingAddress = billingAddress;
        Payment = payment;
        Date = date;
        Status = status;

        AddDomainEvent(new ReservationUpdatedEvent(this));
    }

}