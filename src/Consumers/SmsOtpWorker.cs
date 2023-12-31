using System.Text;
using Newtonsoft.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Events;
using RabbitMQ.Client.Events;

namespace Consumers;

public class SmsOtpWorker(ILogger<SmsOtpWorker> logger, IRabbitMqContext rabbitMqContext)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(rabbitMqContext.Channel);
        consumer.Received += async (ch, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            var message = JsonConvert.DeserializeObject<SendSmsOtpEvent>(content);
            logger.LogInformation($"Received {message}");
            
            
            await Task.Delay(1000, stoppingToken);
            rabbitMqContext.Channel.BasicAck(ea.DeliveryTag, false);
        };
        rabbitMqContext.Channel.BasicConsume("sms-otp", false, "", false, false, null, consumer);

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}
