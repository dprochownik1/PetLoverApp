using MassTransit;
using Microsoft.FeatureManagement;

namespace Booking.Application.Reservations.EventHandlers.Domain;

public class ReservationUpdatedEventHandler(IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager, ILogger<ReservationUpdatedEventHandler> logger)
    : INotificationHandler<ReservationUpdatedEvent>
{
    private const string ReservationFulfillment = "ReservationFulfillment";

    public async Task Handle(ReservationUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        if (featureManager.IsEnabledAsync(ReservationFulfillment).GetAwaiter().GetResult())
        {
            var reservationUpdatedEvent = domainEvent.Reservation.Adapt<ReservationUpdatedEvent>();
            await publishEndpoint.Publish(reservationUpdatedEvent, cancellationToken);
        }

        logger.LogInformation($"Domain Event handled: {domainEvent.GetType().Name}");
    }
}