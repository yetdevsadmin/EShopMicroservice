namespace Ordering.Application.Orders.EventHandlers;

public class OrderUpdatedEventhandler(ILogger<OrderUpdatedEventhandler> logger) : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order Updated Event: {DomainEVent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
