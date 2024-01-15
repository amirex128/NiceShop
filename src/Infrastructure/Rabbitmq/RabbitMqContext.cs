using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using RabbitMQ.Client;

namespace NiceShop.Infrastructure.Rabbitmq;

public class RabbitMqContext : IRabbitMqContext
{
    private readonly IConnection _connection;
    public IModel Channel { get; }

    public RabbitMqContext(IConfiguration configuration, ILogger<RabbitMqContext> logger)
    {
        try
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(configuration["RabbitMq:HostName"] ?? string.Empty),
                UserName = configuration["RabbitMq:UserName"],
                Password = configuration["RabbitMq:Password"],
            };

            _connection = factory.CreateConnection();
            Channel = _connection.CreateModel();

            Channel.ExchangeDeclare("ex.topic", ExchangeType.Topic, true);

            var arguments = new Dictionary<string, object> { { "x-dead-letter-exchange", "ex.topic" }, };

            Channel.QueueDeclare("eita", true, false, false, arguments);
            Channel.QueueDeclare("sms", true, false, false, arguments);
            Channel.QueueDeclare("email", true, false, false, arguments);
            Channel.QueueDeclare("notification", true, false, false, arguments);

            Channel.QueueBind("eita", "ex.topic", "notification.eita.otp", null);
            Channel.QueueBind("sms", "ex.topic", "notification.sms.otp", null);
            Channel.QueueBind("email", "ex.topic", "notification.email.otp", null);
            Channel.QueueBind("notification", "ex.topic", "notification.#", null);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to connect to RabbitMQ");
            throw;
        }
    }

    public void Close()
    {
        Channel.Close();
        _connection.Close();
    }
}
