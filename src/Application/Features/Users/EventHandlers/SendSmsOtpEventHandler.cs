using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Events;

namespace NiceShop.Application.Features.Users.EventHandlers;

public class SendSmsOtpEventHandler(ILogger<SendSmsOtpEventHandler> logger, IRabbitMqContext rabbitMq)
    : INotificationHandler<SendSmsOtpEvent>
{
    public Task Handle(SendSmsOtpEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("NiceShop Domain Event: {DomainEvent}", notification.GetType().Name);

        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification));

        rabbitMq.Channel.BasicPublish(
            exchange: "amq.direct",
            routingKey: "sms",
            basicProperties: null,
            body: message,
            mandatory: false
        );

        return Task.CompletedTask;
    }
}
