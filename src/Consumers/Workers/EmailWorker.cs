using System.Text;
using Newtonsoft.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Events;

namespace Consumers.Workers;

public class EmailWorker(
    ILogger<EmailWorker> logger,
    IRabbitmqService rabbitmqService,
    IRabbitMqContext rabbitMqContext)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        rabbitmqService.ConsumeSms((ch, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            var message = JsonConvert.DeserializeObject<SendOtpEvent>(content);
            if (message is null)
            {
                return;
            }

            logger.LogInformation($"Received {message.Otp} from {message.Phone}");

            rabbitMqContext.Channel.BasicAck(ea.DeliveryTag, false);
        });

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}
