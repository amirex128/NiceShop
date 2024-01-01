using System.Text;
using Newtonsoft.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Events;
using RabbitMQ.Client.Events;

namespace NiceShop.Application.Services;

public class RabbitmqService(IRabbitMqContext rabbitMqContext) : IRabbitmqService
{
    public void PublishSmsOtp(object message)
    {
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        rabbitMqContext.Channel.BasicPublish(
            exchange: "ex.topic",
            routingKey: "notification.sms.otp",
            basicProperties: null,
            body: body,
            mandatory: false
        );
    }

    public void PublishEmailOtp(object message)
    {
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        rabbitMqContext.Channel.BasicPublish(
            exchange: "ex.topic",
            routingKey: "notification.email.otp",
            basicProperties: null,
            body: body,
            mandatory: false
        );
    }

    public void ConsumeSms(EventHandler<BasicDeliverEventArgs> consumerFunc)
    {
        var consumer = new EventingBasicConsumer(rabbitMqContext.Channel);
        consumer.Received += consumerFunc;
        rabbitMqContext.Channel.BasicConsume("sms", false, "", false, false, null, consumer);
    }

    public void ConsumeEmail(EventHandler<BasicDeliverEventArgs> consumerFunc)
    {
        var consumer = new EventingBasicConsumer(rabbitMqContext.Channel);
        consumer.Received += consumerFunc;
        rabbitMqContext.Channel.BasicConsume("email", false, "", false, false, null, consumer);
    }

    public void ConsumeNotification(EventHandler<BasicDeliverEventArgs> consumerFunc)
    {
        var consumer = new EventingBasicConsumer(rabbitMqContext.Channel);
        consumer.Received += consumerFunc;
        rabbitMqContext.Channel.BasicConsume("notification", false, "", false, false, null, consumer);
    }
}
