using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Events;

namespace NiceShop.Application.Features.Users.EventHandlers;

public class SendOtpEventHandler(ILogger<SendOtpEventHandler> logger, IRabbitmqService rabbitmqService)
    : INotificationHandler<SendOtpEvent>
{
    public Task Handle(SendOtpEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("NiceShop Domain Event: {DomainEvent}", notification.GetType().Name);
        
        rabbitmqService.PublishSmsOtp(notification);
        rabbitmqService.PublishEmailOtp(notification);

        return Task.CompletedTask;
    }
}
