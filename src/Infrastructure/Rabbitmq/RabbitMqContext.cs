using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using RabbitMQ.Client;

namespace NiceShop.Infrastructure.Rabbitmq;

public class RabbitMqContext : IRabbitMqContext
{
    private readonly IConnection _connection;
    public IModel Channel { get; }

    public RabbitMqContext(IConfiguration configuration,ILogger<RabbitMqContext> logger)
    {
        logger.LogInformation("------------------------------------");
        logger.LogInformation(configuration["RabbitMq:HostName"]);
        logger.LogInformation(configuration["RabbitMq:Port"]);
        logger.LogInformation(configuration["RabbitMq:UserName"]);
        var factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMq:HostName"],
            UserName = configuration["RabbitMq:UserName"],
            Password = configuration["RabbitMq:Password"],
            Port = int.Parse(configuration["RabbitMq:Port"] ?? "5672"),
            VirtualHost = configuration["RabbitMq:VirtualHost"],
        };
        
        _connection = factory.CreateConnection();
        Channel = _connection.CreateModel();

        Channel.ExchangeDeclare("ex.topic", ExchangeType.Topic,true);
        
        var arguments = new Dictionary<string, object>
        {
            { "x-dead-letter-exchange", "ex.topic" },
        };
        
        Channel.QueueDeclare("sms", true, false, false, arguments);
        Channel.QueueDeclare("email", true, false, false, arguments);
        Channel.QueueDeclare("notification", true, false, false, arguments);
        
        Channel.QueueBind("sms", "ex.topic", "notification.sms.otp", null);
        Channel.QueueBind("email", "ex.topic", "notification.email.otp", null);
        Channel.QueueBind("notification", "ex.topic", "notification.#", null);
        
    }

    public void Close()
    {
        Channel.Close();
        _connection.Close();
    }
}
