using Microsoft.Extensions.Configuration;
using NiceShop.Application.Common.Interfaces;
using RabbitMQ.Client;

namespace NiceShop.Infrastructure.Rabbitmq;

public class RabbitMqContext : IRabbitMqContext
{
    private readonly IConnection _connection;
    public IModel Channel { get; }

    public RabbitMqContext(IConfiguration configuration)
    {
        var factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMq:HostName"],
            UserName = configuration["RabbitMq:UserName"],
            Password = configuration["RabbitMq:Password"],
            Port = int.Parse(configuration["RabbitMq:Port"] ?? "5672")
        };
        _connection = factory.CreateConnection();
        Channel = _connection.CreateModel();

        Channel.QueueDeclare(queue: "otp-sms",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void Close()
    {
        Channel.Close();
        _connection.Close();
    }
}
