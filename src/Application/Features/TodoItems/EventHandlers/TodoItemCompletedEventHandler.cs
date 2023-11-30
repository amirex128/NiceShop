using Microsoft.Extensions.Logging;
using NiceShop.Domain.Events;

namespace NiceShop.Application.Features.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("NiceShop Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
