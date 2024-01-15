using System.Text;
using Newtonsoft.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Events;

namespace Consumers.Workers;

public class EitaWorker(
    ILogger<EitaWorker> logger,
    IRabbitmqService rabbitmqService,
    IRabbitMqContext rabbitMqContext,
    IEitaService eitaService)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        rabbitmqService.ConsumeEita((ch, ea) =>
        {
            try
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var message = JsonConvert.DeserializeObject<SendOtpEvent>(content);
                if (message is null)
                {
                    return;
                }

                eitaService.SendOtpAsync(message.Otp);
                logger.LogInformation($"Received {message.Otp} from {message.Phone}");

                rabbitMqContext.Channel.BasicAck(ea.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when consuming sms");
                if (ea.Redelivered)
                {
                    rabbitMqContext.Channel.BasicNack(ea.DeliveryTag, false, false);
                }
                else
                {
                    rabbitMqContext.Channel.BasicNack(ea.DeliveryTag, false, true);
                }
            }
        });

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}
