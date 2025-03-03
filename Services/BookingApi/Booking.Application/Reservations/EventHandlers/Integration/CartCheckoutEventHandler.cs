using Booking.Application.Reservations.Commands.CreateReservation;
using Common.Lib.Events;
using MassTransit;

namespace Booking.Application.Reservations.EventHandlers.Integration;

public class CartCheckoutEventHandler(ISender sender, ILogger<CartCheckoutEventHandler> logger)
    : IConsumer<CartCheckoutEvent>
{
    public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
    {
        var command = context.Message.Adapt<CreateReservationCommand>();
        await sender.Send(command);

        logger.LogInformation($"Integration Event handled: {context.Message.GetType().Name}");
    }
}