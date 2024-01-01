using RabbitMQ.Client.Events;

namespace NiceShop.Application.Common.Interfaces;

public interface IRabbitmqService
{
    public void PublishSmsOtp(object message);
    public void PublishEmailOtp(object message);
    public void ConsumeSms(EventHandler<BasicDeliverEventArgs> consumerFunc);
    public void ConsumeEmail(EventHandler<BasicDeliverEventArgs> consumerFunc);
    public void ConsumeNotification(EventHandler<BasicDeliverEventArgs> consumerFunc);


}
