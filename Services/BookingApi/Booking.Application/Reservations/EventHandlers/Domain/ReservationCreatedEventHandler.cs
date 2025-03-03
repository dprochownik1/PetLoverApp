using MassTransit;
using Microsoft.FeatureManagement;

namespace Booking.Application.Reservations.EventHandlers.Domain;

public class ReservationCreatedEventHandler(IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager, ILogger<ReservationCreatedEventHandler> logger)
    : INotificationHandler<ReservationCreatedEvent>
{
    private const string ReservationFulfillment = "ReservationFulfillment";

    public async Task Handle(ReservationCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        if (featureManager.IsEnabledAsync(ReservationFulfillment).GetAwaiter().GetResult())
        {
            var orderCreatedIntegrationEvent = domainEvent.Reservation.Adapt<ReservationCreatedEvent>();
            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }

        logger.LogInformation($"Domain Event handled: {domainEvent.GetType().Name}");
    }
}