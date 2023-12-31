using RabbitMQ.Client;

namespace NiceShop.Application.Common.Interfaces;

public interface IRabbitMqContext
{
    public IModel Channel { get; }

}
