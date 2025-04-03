namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderUpdatedEventhandler(ILogger<OrderUpdatedEventhandler> logger) : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order Updated Event: {DomainEVent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
